using Noxy.NET.Test.Domain.Entities.Data.Discriminators;

namespace Noxy.NET.Test.Domain.Entities.Data;

public class EntityDataPropertyDateTime : EntityDataProperty
{
    public required DateTime? Value { get; set; }
}
