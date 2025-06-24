using Noxy.NET.Test.Domain.Abstractions.Entities;

namespace Noxy.NET.Test.Domain.Entities.Schemas.Junctions;

public class EntityJunctionSchemaActionHasDynamicValueCode : BaseEntityManyToMany<EntitySchemaAction, EntitySchemaDynamicValueCode>
{
    public required int Order { get; set; }
}
