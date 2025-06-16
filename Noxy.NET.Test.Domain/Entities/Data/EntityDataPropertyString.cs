using Noxy.NET.Test.Domain.Entities.Data.Discriminators;

namespace Noxy.NET.Test.Domain.Entities.Data;

public class EntityDataPropertyString : EntityDataProperty
{
    public required string? Value { get; set; }
}
