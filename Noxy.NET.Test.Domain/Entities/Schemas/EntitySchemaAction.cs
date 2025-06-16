using System.Text.Json.Serialization;
using Noxy.NET.Test.Domain.Abstractions.Entities;
using Noxy.NET.Test.Domain.Entities.Schemas.Discriminators;
using Noxy.NET.Test.Domain.Entities.Schemas.Junctions;
using Noxy.NET.Test.Domain.ViewModels;

namespace Noxy.NET.Test.Domain.Entities.Schemas;

public class EntitySchemaAction : BaseEntitySchemaComponent
{
    public EntitySchemaDynamicValue.Discriminator? TitleDynamic { get; set; }
    public required Guid TitleDynamicID { get; set; }

    public List<EntityJunctionSchemaActionHasActionStep>? ActionStepList { get; set; }
    public List<EntityJunctionSchemaActionHasDynamicValueCode>? DynamicValueCodeList { get; set; }

    [JsonIgnore]
    public List<EntityJunctionSchemaContextHasAction>? ContextList { get; set; }
    
    public ViewModelSchemaAction ToViewModel()
    {
        return new()
        {
            ID = ID,
            SchemaIdentifier = SchemaIdentifier,
            Order = Order,
            Title = Title,
            TitleDynamic = TitleDynamic?.ToViewModel(),
            Description = Description,
            ActionStepList = ActionStepList?.Select(x => x.Relation?.ToViewModel() ?? throw new InvalidOperationException()).ToArray()
        };
    }
}
