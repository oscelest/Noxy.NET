namespace Noxy.NET.Test.Domain.Abstractions.Entities;

public abstract class BaseEntityData : BaseEntity
{
    public required string SchemaIdentifier { get; set; }
}