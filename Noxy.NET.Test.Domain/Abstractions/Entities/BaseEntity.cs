namespace Noxy.NET.Test.Domain.Abstractions.Entities;

public abstract class BaseEntity
{
    public Guid ID { get; init; } = Guid.NewGuid();
    public DateTime? TimeCreated { get; set; } = DateTime.UtcNow;
}