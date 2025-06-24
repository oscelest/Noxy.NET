using Noxy.NET.Test.Domain.Abstractions.Entities;

namespace Noxy.NET.Test.Domain.Entities.Schemas.Junctions;

public class EntityJunctionSchemaInputHasAttribute : BaseEntityManyToMany<EntitySchemaInput, EntitySchemaAttribute>
{
    public required int Order { get; set; }
}
