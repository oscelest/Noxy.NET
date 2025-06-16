using Noxy.NET.Test.Domain.Abstractions.Entities;
using Noxy.NET.Test.Domain.Entities.Schemas.Discriminators;

namespace Noxy.NET.Test.Domain.Entities.Schemas.Junctions;

public class EntityJunctionSchemaElementHasProperty : BaseEntityJunction<EntitySchemaElement, EntitySchemaProperty.Discriminator>;
