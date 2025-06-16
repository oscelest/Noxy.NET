using System.Text.Json.Serialization;
using Noxy.NET.Test.Domain.Abstractions.Entities;
using Noxy.NET.Test.Domain.Entities.Schemas.Junctions;
using Noxy.NET.Test.Domain.ViewModels;

namespace Noxy.NET.Test.Domain.Entities.Schemas;

public class EntitySchemaInput : BaseEntitySchema
{
    public List<EntityJunctionSchemaInputHasAttribute>? AttributeList { get; set; }

    [JsonIgnore]
    public List<EntitySchemaActionInput>? ActionInputList { get; set; }

    public ViewModelSchemaInput ToViewModel()
    {
        return new()
        {
            ID = ID,
            SchemaIdentifier = SchemaIdentifier
        };
    }
}
