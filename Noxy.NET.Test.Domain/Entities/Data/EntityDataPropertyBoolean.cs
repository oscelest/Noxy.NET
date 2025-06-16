using Noxy.NET.Test.Domain.Entities.Data.Discriminators;

namespace Noxy.NET.Test.Domain.Entities.Data;

public class EntityDataPropertyBoolean : EntityDataProperty
{
    public required bool? Value { get; set; }
}
