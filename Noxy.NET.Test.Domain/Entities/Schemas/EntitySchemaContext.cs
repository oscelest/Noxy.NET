using Noxy.NET.Test.Domain.Abstractions.Entities;
using Noxy.NET.Test.Domain.Entities.Schemas.Junctions;

namespace Noxy.NET.Test.Domain.Entities.Schemas;

public class EntitySchemaContext : BaseEntitySchemaComponent
{
    public List<EntityJunctionSchemaContextHasAction>? ActionList { get; set; }
    public List<EntityJunctionSchemaContextHasElement>? ElementList { get; set; }
}
