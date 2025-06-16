using System.Text.Json.Serialization;
using Noxy.NET.Test.Domain.Abstractions.Entities;
using Noxy.NET.Test.Domain.Entities.Schemas.Junctions;

namespace Noxy.NET.Test.Domain.Entities.Schemas;

public class EntitySchemaElement : BaseEntitySchemaComponent
{
    public List<EntityJunctionSchemaElementHasProperty>? PropertyList { get; set; }

    [JsonIgnore]
    public List<EntityJunctionSchemaContextHasElement>? ContextList { get; set; }

    [JsonIgnore]
    public List<EntitySchemaGroupElement>? GroupElementList { get; set; }
}
