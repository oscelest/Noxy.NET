using System.Text.Json.Serialization;
using Noxy.NET.Test.Domain.Abstractions.Entities;
using Noxy.NET.Test.Domain.Entities.Schemas.Junctions;
using Noxy.NET.Test.Domain.ViewModels;

namespace Noxy.NET.Test.Domain.Entities.Schemas;

public class EntitySchemaActionStep : BaseEntitySchemaComponent
{
    public required bool IsRepeatable { get; set; }
    
    public List<EntityJunctionSchemaActionStepHasActionInput>? ActionInputList { get; set; }
    
    [JsonIgnore]
    public List<EntityJunctionSchemaActionHasActionStep>? ActionList { get; set; }

    public ViewModelSchemaActionStep ToViewModel()
    {
        return new()
        {
            ID = ID,
            SchemaIdentifier = SchemaIdentifier,
            Order = Order,
            Title = Title,
            Description = Description,
            ActionInputList = ActionInputList?.Select(x => x.Relation?.ToViewModel() ?? throw new InvalidOperationException()).ToArray()
        };
    }
}
