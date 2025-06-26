using System.ComponentModel.DataAnnotations;
using Noxy.NET.Test.Domain.Abstractions.Entities;

namespace Noxy.NET.Test.Domain.Abstractions.Forms;

public abstract class BaseFormModelEntityAssociation : BaseFormModelEntity
{
    [Required]
    public Guid EntityID { get; set; }

    [Required]
    public Guid RelationID { get; set; }
    
    protected BaseFormModelEntityAssociation(BaseEntityManyToMany? entity) : base(entity)
    {
        EntityID = entity?.EntityID ?? Guid.Empty;
        RelationID = entity?.RelationID ?? Guid.Empty;
    }

    protected BaseFormModelEntityAssociation(BaseEntity? entity, BaseEntity? relation) : base(null)
    {
        EntityID = entity?.ID ?? Guid.Empty;
        RelationID = relation?.ID ?? Guid.Empty;
    }

}
