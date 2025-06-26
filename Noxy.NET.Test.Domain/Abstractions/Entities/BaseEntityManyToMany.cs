using System.Text.Json.Serialization;

namespace Noxy.NET.Test.Domain.Abstractions.Entities;

public abstract class BaseEntityManyToMany<TEntity, TRelation> : BaseEntityManyToMany where TEntity : BaseEntity where TRelation : BaseEntity
{
    [JsonIgnore]
    public TEntity? Entity { get; set; }
    public TRelation? Relation { get; set; }
}

public abstract class BaseEntityManyToMany : BaseEntity
{
    public required Guid EntityID { get; set; }
    public required Guid RelationID { get; set; }
}
