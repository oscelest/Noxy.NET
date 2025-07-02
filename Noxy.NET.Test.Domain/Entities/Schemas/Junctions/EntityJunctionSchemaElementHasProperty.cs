using Noxy.NET.Test.Domain.Abstractions.Entities;
using Noxy.NET.Test.Domain.Entities.Schemas.Discriminators;

namespace Noxy.NET.Test.Domain.Entities.Schemas.Junctions;

public class EntityJunctionSchemaElementHasProperty : BaseEntityManyToMany<EntitySchemaElement, EntitySchemaProperty.Discriminator>
{
    public required int Order { get; set; }
    
    public override string ToString()
    {
        return Relation?.GetValue().Name ?? ID.ToString();
    }
}
