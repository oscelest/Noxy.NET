using Noxy.NET.Test.Domain.Enums;
using Noxy.NET.Test.Persistence;
using Noxy.NET.Test.Persistence.Tables.Schemas;
using Noxy.NET.Test.Persistence.Tables.Schemas.Discriminators;

namespace Noxy.NET.Test.Database.Builders;

public class SchemaSeedBuilder(DataContext context, TableSchema schema)
{
    public DateTime Now { get; } = DateTime.UtcNow;
    private Dictionary<string, int> OrderCollection { get; } = [];

    public static TableSchema CreateSchema(string name, string note = "", int order = 1, bool isActive = false, DateTime? timeActivated = null, DateTime? timeCreated = null)
    {
        return new()
        {
            Name = name,
            Note = note,
            Order = order,
            IsActive = isActive,
            TimeActivated = timeActivated,
            TimeCreated = timeCreated ?? DateTime.UtcNow,
        };
    }

    public TableSchemaAction AddAction(string identifier, TableSchemaDynamicValue refTitle, string name, string title, string note = "", string description = "", DateTime? timeCreated = null)
    {
        return context.SchemaAction.Add(new()
        {
            SchemaIdentifier = identifier,
            Name = name,
            Note = note,
            Order = GetNextOrder(nameof(TableSchemaAction)),
            Title = title,
            Description = description,
            SchemaID = schema.ID,
            TitleDynamicID = refTitle.ID,
            TimeCreated = timeCreated ?? Now,
        }).Entity;
    }

    public TableSchemaActionInput AddActionInput(string identifier, TableSchemaInput refSchemaInput, string name, string title, string note = "", string description = "", DateTime? timeCreated = null)
    {
        return context.SchemaActionInput.Add(new()
        {
            SchemaIdentifier = identifier,
            Name = name,
            Note = note,
            Order = GetNextOrder(nameof(TableSchemaActionInput)),
            Title = title,
            Description = description,
            SchemaID = schema.ID,
            InputID = refSchemaInput.ID,
            TimeCreated = timeCreated ?? Now,
        }).Entity;
    }

    public TableSchemaActionStep AddActionStep(string identifier, string name, string title, string note = "", string description = "", DateTime? timeCreated = null)
    {
        return context.SchemaActionStep.Add(new()
        {
            SchemaIdentifier = identifier,
            Name = name,
            Note = note,
            Order = GetNextOrder(nameof(TableSchemaActionStep)),
            Title = title,
            Description = description,
            SchemaID = schema.ID,
            TimeCreated = timeCreated ?? Now,
        }).Entity;
    }

    public TableSchemaAttribute AddAttribute(string identifier, string name, string note = "", AttributeTypeEnum type = AttributeTypeEnum.String, bool isList = false, DateTime? timeCreated = null)
    {
        return context.SchemaAttribute.Add(new()
        {
            SchemaIdentifier = identifier,
            Name = name,
            Note = note,
            Order = GetNextOrder(nameof(TableSchemaAttribute)),
            Type = type,
            IsList = isList,
            SchemaID = schema.ID,
            TimeCreated = timeCreated ?? Now,
        }).Entity;
    }

    public TableSchemaContext AddContext(string identifier, string name, string title, string note = "", string description = "", DateTime? timeCreated = null)
    {
        return context.SchemaContext.Add(new()
        {
            SchemaIdentifier = identifier,
            Name = name,
            Note = note,
            Order = GetNextOrder(nameof(TableSchemaContext)),
            Title = title,
            Description = description,
            SchemaID = schema.ID,
            TimeCreated = timeCreated ?? Now,
        }).Entity;
    }

    public TableSchemaDynamicValueCode AddDynamicValueCode(string identifier, string name, string value, string note = "", bool isAsynchronous = false, DateTime? timeCreated = null)
    {
        return context.SchemaDynamicValueCode.Add(new()
        {
            SchemaIdentifier = identifier,
            Name = name,
            Note = note,
            Order = GetNextOrder(nameof(TableSchemaDynamicValueCode)),
            SchemaID = schema.ID,
            Value = value,
            IsAsynchronous = isAsynchronous,
            TimeCreated = timeCreated ?? Now,
        }).Entity;
    }

    public TableSchemaDynamicValueSystemParameter AddDynamicValueSystemParameter(string identifier, string name, string note = "", bool isApprovalRequired = false, DateTime? timeCreated = null)
    {
        return context.SchemaDynamicValueSystemParameter.Add(new()
        {
            SchemaIdentifier = identifier,
            Name = name,
            Note = note,
            Order = GetNextOrder(nameof(TableSchemaDynamicValueTextParameter)),
            IsApprovalRequired = isApprovalRequired,
            SchemaID = schema.ID,
            TimeCreated = timeCreated ?? Now,
        }).Entity;
    }

    public TableSchemaDynamicValueTextParameter AddDynamicValueTextParameter(string identifier, string name, TextParameterTypeEnum type = TextParameterTypeEnum.Line, string note = "", bool isApprovalRequired = false, DateTime? timeCreated = null)
    {
        return context.SchemaDynamicValueTextParameter.Add(new()
        {
            SchemaIdentifier = identifier,
            Name = name,
            Note = note,
            Order = GetNextOrder(nameof(TableSchemaDynamicValueTextParameter)),
            Type = type,
            IsApprovalRequired = isApprovalRequired,
            SchemaID = schema.ID,
            TimeCreated = timeCreated ?? Now,
        }).Entity;
    }

    public TableSchemaElement AddElement(string identifier, string name, string title, string note = "", string description = "", DateTime? timeCreated = null)
    {
        return context.SchemaElement.Add(new()
        {
            SchemaIdentifier = identifier,
            Name = name,
            Note = note,
            Order = GetNextOrder(nameof(TableSchemaElement)),
            Title = title,
            Description = description,
            SchemaID = schema.ID,
            TimeCreated = timeCreated ?? Now,
        }).Entity;
    }

    public TableSchemaInput AddInput(string identifier, string name, string note = "", DateTime? timeCreated = null)
    {
        return context.SchemaInput.Add(new()
        {
            SchemaIdentifier = identifier,
            Name = name,
            Note = note,
            Order = GetNextOrder(nameof(TableSchemaInput)),
            SchemaID = schema.ID,
            TimeCreated = timeCreated ?? Now,
        }).Entity;
    }

    public TableSchemaPropertyBoolean AddPropertyBoolean(string identifier, string name, string title, string note = "", string description = "", string @default = "", DateTime? timeCreated = null)
    {
        return context.SchemaPropertyBoolean.Add(new()
        {
            SchemaIdentifier = identifier,
            Name = name,
            Note = note,
            Order = GetNextOrder(nameof(TableSchemaProperty)),
            Title = title,
            Description = description,
            DefaultValue = @default,
            SchemaID = schema.ID,
            TimeCreated = timeCreated ?? Now,
        }).Entity;
    }

    public TableSchemaPropertyDateTime AddPropertyDateTime(string identifier, string name, string title, string note = "", string description = "", string @default = "", DateTime? timeCreated = null)
    {
        return context.SchemaPropertyDateTime.Add(new()
        {
            SchemaIdentifier = identifier,
            Name = name,
            Note = note,
            Order = GetNextOrder(nameof(TableSchemaProperty)),
            Title = title,
            Description = description,
            DefaultValue = @default,
            SchemaID = schema.ID,
            TimeCreated = timeCreated ?? Now,
        }).Entity;
    }

    public TableSchemaPropertyString AddPropertyString(string identifier, string name, string title, string note = "", string description = "", string @default = "", DateTime? timeCreated = null)
    {
        return context.SchemaPropertyString.Add(new()
        {
            SchemaIdentifier = identifier,
            Name = name,
            Note = note,
            Order = GetNextOrder(nameof(TableSchemaProperty)),
            Title = title,
            Description = description,
            DefaultValue = @default,
            SchemaID = schema.ID,
            TimeCreated = timeCreated ?? Now,
        }).Entity;
    }

    public void Relate(TableSchemaAction refAction, TableSchemaDynamicValueCode refDynamicValueCode, DateTime? timeCreated = null)
    {
        context.SchemaActionHasDynamicValueCode.Add(new()
        {
            Entity = refAction,
            EntityID = refAction.ID,
            Relation = refDynamicValueCode,
            RelationID = refDynamicValueCode.ID,
            Order = GetNextOrder(nameof(TableSchemaAction) + nameof(TableSchemaDynamicValueCode)),
            TimeCreated = timeCreated ?? Now,
        });
    }

    public void Relate(TableSchemaAction refAction, TableSchemaActionStep refActionStep, DateTime? timeCreated = null)
    {
        context.SchemaActionHasActionStep.Add(new()
        {
            Entity = refAction,
            EntityID = refAction.ID,
            Relation = refActionStep,
            RelationID = refActionStep.ID,
            Order = GetNextOrder(nameof(TableSchemaAction) + nameof(TableSchemaActionStep)),
            TimeCreated = timeCreated ?? Now,
        });
    }

    public void Relate(TableSchemaActionStep refActionStep, TableSchemaActionInput refActionInput, DateTime? timeCreated = null)
    {
        context.SchemaActionStepHasActionInput.Add(new()
        {
            Entity = refActionStep,
            EntityID = refActionStep.ID,
            Relation = refActionInput,
            RelationID = refActionInput.ID,
            Order = GetNextOrder(nameof(TableSchemaActionStep) + nameof(TableSchemaActionInput)),
            TimeCreated = timeCreated ?? Now,
        });
    }

    public void Relate(TableSchemaActionInput refInput, TableSchemaAttribute refAttribute, string value, DateTime? timeCreated = null)
    {
        context.SchemaActionInputHasAttributeString.Add(new()
        {
            Entity = refInput,
            EntityID = refInput.ID,
            Relation = refAttribute,
            RelationID = refAttribute.ID,
            Value = value,
            TimeCreated = timeCreated ?? Now,
        });
    }

    public void Relate(TableSchemaActionInput refInput, TableSchemaAttribute refAttribute, int value, DateTime? timeCreated = null)
    {
        context.SchemaActionInputHasAttributeInteger.Add(new()
        {
            Entity = refInput,
            EntityID = refInput.ID,
            Relation = refAttribute,
            RelationID = refAttribute.ID,
            Value = value,
            TimeCreated = timeCreated ?? Now,
        });
    }

    public void Relate(TableSchemaActionInput refInput, TableSchemaAttribute refAttribute, TableSchemaDynamicValue refDynamicValue, DateTime? timeCreated = null)
    {
        context.SchemaActionInputHasAttributeDynamicValue.Add(new()
        {
            Entity = refInput,
            EntityID = refInput.ID,
            Relation = refAttribute,
            RelationID = refAttribute.ID,
            ValueID = refDynamicValue.ID,
            TimeCreated = timeCreated ?? Now,
        });
    }

    public void Relate(TableSchemaContext refContext, TableSchemaAction refAction, DateTime? timeCreated = null)
    {
        context.SchemaContextHasAction.Add(new()
        {
            Entity = refContext,
            EntityID = refContext.ID,
            Relation = refAction,
            RelationID = refAction.ID,
            TimeCreated = timeCreated ?? Now,
        });
    }

    public void Relate(TableSchemaContext refContext, TableSchemaElement refElement, DateTime? timeCreated = null)
    {
        context.SchemaContextHasElement.Add(new()
        {
            Entity = refContext,
            EntityID = refContext.ID,
            Relation = refElement,
            RelationID = refElement.ID,
            TimeCreated = timeCreated ?? Now,
        });
    }

    public void Relate(TableSchemaElement refElement, TableSchemaProperty refProperty, DateTime? timeCreated = null)
    {
        context.SchemaElementHasProperty.Add(new()
        {
            Entity = refElement,
            EntityID = refElement.ID,
            Relation = refProperty,
            RelationID = refProperty.ID,
            Order = GetNextOrder(nameof(TableSchemaInput) + nameof(TableSchemaAttribute)),
            TimeCreated = timeCreated ?? Now,
        });
    }

    public void Relate(TableSchemaInput refInput, TableSchemaAttribute refAttribute, DateTime? timeCreated = null)
    {
        context.SchemaInputHasAttribute.Add(new()
        {
            Entity = refInput,
            EntityID = refInput.ID,
            Relation = refAttribute,
            RelationID = refAttribute.ID,
            Order = GetNextOrder(nameof(TableSchemaInput) + nameof(TableSchemaAttribute)),
            TimeCreated = timeCreated ?? Now,
        });
    }

    private int GetNextOrder(string identifier)
    {
        if (!OrderCollection.TryGetValue(identifier, out int value))
        {
            OrderCollection[identifier] = value = 0;
        }

        return OrderCollection[identifier] = value + 1;
    }
}
