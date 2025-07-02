using Noxy.NET.Test.Domain.Abstractions.Entities;

namespace Noxy.NET.Test.Domain.Entities.Schemas.Junctions;

public class EntityJunctionSchemaActionHasActionStep : BaseEntityManyToMany<EntitySchemaAction, EntitySchemaActionStep>
{
    public required int Order { get; set; }
    
    public override string ToString()
    {
        return Relation?.Name ?? ID.ToString();
    }
}
