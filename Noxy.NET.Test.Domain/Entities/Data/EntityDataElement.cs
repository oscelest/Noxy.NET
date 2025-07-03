using Noxy.NET.Test.Domain.Abstractions.Entities;
using Noxy.NET.Test.Domain.Entities.Data.Discriminators;

namespace Noxy.NET.Test.Domain.Entities.Data;

public class EntityDataElement : BaseEntityData
{
    public List<EntityDataProperty.Discriminator>? PropertyList { get; set; }
}
