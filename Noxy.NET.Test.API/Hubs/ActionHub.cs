using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Noxy.NET.Models;
using Noxy.NET.Test.Application.Interfaces.Hubs;
using Noxy.NET.Test.Application.Interfaces.Services;
using Noxy.NET.Test.Domain.Entities.Schemas;
using Noxy.NET.Test.Domain.Entities.Schemas.Associations;
using Noxy.NET.Test.Domain.Entities.Schemas.Discriminators;
using Noxy.NET.Test.Domain.Entities.Schemas.Junctions;
using Noxy.NET.Test.Domain.Models;

namespace Noxy.NET.Test.API.Hubs;

[Authorize]
public class ActionHub(IApplicationService serviceApplication, IDynamicValueService serviceDynamicValue) : Hub<IActionClientHub>, IActionServerHub
{
    private static readonly Dictionary<string, ActionManager> Data = new();

    private string UserIdentifier => Context.User?.Claims.Single(x => x.Type == ClaimTypes.Email).Value ?? throw new ArgumentNullException();

    public StateAction Register(Guid id, string identifier, Dictionary<string, object?>? context = null)
    {
        if (!Data.TryGetValue(UserIdentifier, out ActionManager? manager))
        {
            manager = Data[UserIdentifier] = new();
        }

        manager.Register(id, serviceApplication.GetSchemaAction(identifier), context);
        return GenerateActionState(id, manager);
    }

    public void Deregister(Guid id)
    {
        if (!Data.TryGetValue(UserIdentifier, out ActionManager? manager)) throw new InvalidOperationException();
        manager.Deregister(id);
    }

    public StateAction CommitField(Guid id, string identifier, JsonDiscriminator value)
    {
        if (!Data.TryGetValue(UserIdentifier, out ActionManager? manager)) throw new InvalidOperationException();
        manager.SetDataValue(id, identifier, value.GetValue());

        return GenerateActionState(id, manager);
    }

    public object? Submit(Guid id)
    {
        if (!Data.TryGetValue(UserIdentifier, out ActionManager? manager)) throw new InvalidOperationException();

        EntitySchemaAction action = manager.GetAction(id);
        IDictionary<string, object?> data = manager.GetData(id);
        IDictionary<string, object?> context = manager.GetContext(id);

        foreach (EntityJunctionSchemaActionHasDynamicValueCode item in action.DynamicValueCodeList ?? [])
        {
            if (item.Relation == null) continue;
            serviceDynamicValue.Execute(item.Relation.SchemaIdentifier, data, context);
        }

        return null;
    }

    private StateAction GenerateActionState(Guid id, ActionManager manager)
    {
        EntitySchemaAction entityAction = manager.GetAction(id);
        IDictionary<string, object?> data = manager.GetData(id);
        IDictionary<string, object?> context = manager.GetContext(id);

        Dictionary<string, StateActionField> collectionField = [];
        foreach (EntityJunctionSchemaActionHasActionStep junctionStep in entityAction.ActionStepList ?? [])
        {
            EntitySchemaActionStep entityActionStep = junctionStep.Relation ?? throw new InvalidOperationException();
            foreach (EntityJunctionSchemaActionStepHasActionInput junctionInput in entityActionStep.ActionInputList ?? [])
            {
                EntitySchemaActionInput entityActionInput = junctionInput.Relation ?? throw new InvalidOperationException();

                collectionField[entityActionInput.SchemaIdentifier] = new()
                {
                    Title = entityActionInput.Title,
                    Description = entityActionInput.Description,
                    ErrorList = [],
                    IsActive = true,
                    Value = new(data[entityActionInput.SchemaIdentifier]),
                    AttributeCollection = GenerateStateActionFieldAttributeCollection(entityActionInput.AttributeList)
                };
            }
        }

        return new()
        {
            Title = serviceDynamicValue.ResolveAsString(entityAction.TitleDynamic?.GetValue(), data, context) ?? string.Empty,
            Description = entityAction.Description,
            FieldCollection = collectionField,
        };
    }
    
    private Dictionary<string, StateActionFieldAttribute> GenerateStateActionFieldAttributeCollection(List<EntityAssociationSchemaActionInputHasAttribute.Discriminator>? list)
    {
        Dictionary<string, StateActionFieldAttribute> result = [];
        if (list == null) return result;

        foreach (EntityAssociationSchemaActionInputHasAttribute.Discriminator junctionActionInputAttribute in list)
        {
            EntityAssociationSchemaActionInputHasAttribute entityActionInputAttribute = junctionActionInputAttribute.GetValue();
            EntitySchemaAttribute entityAttribute = entityActionInputAttribute.Relation ?? throw new InvalidOperationException();

            result[entityAttribute.SchemaIdentifier] = new()
            {
                Value = GetAttributeValue(junctionActionInputAttribute),
                Type = entityAttribute.Type,
                IsList = entityAttribute.IsList,
                Order = entityAttribute.Order,
            };
        }

        return result;
    }

    private JsonDiscriminator GetAttributeValue(EntityAssociationSchemaActionInputHasAttribute.Discriminator attribute)
    {
        return new(attribute.GetValue() switch
        {
            EntityAssociationSchemaActionInputHasAttributeDynamicValue value => serviceDynamicValue.Resolve(value.Value?.GetValue()),
            EntityAssociationSchemaActionInputHasAttributeInteger value => value.Value,
            EntityAssociationSchemaActionInputHasAttributeString value => value.Value,
            _ => throw new InvalidOperationException()
        });
    }
}
