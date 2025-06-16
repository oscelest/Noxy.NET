using System.Text.Json.Serialization;

namespace Noxy.NET.Test.Domain.Abstractions.Entities;

public abstract class BaseEntityAssociation<TEntity, TRelation> : BaseEntity where TEntity : BaseEntity where TRelation : BaseEntity
{
    [JsonIgnore]
    public TEntity? Entity { get; set; }
    public required Guid EntityID { get; set; }

    public TRelation? Relation { get; set; }
    public required Guid RelationID { get; set; }
}
