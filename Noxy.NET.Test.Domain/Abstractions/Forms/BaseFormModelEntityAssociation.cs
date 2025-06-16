using System.ComponentModel.DataAnnotations;
using Noxy.NET.Test.Domain.Abstractions.Entities;

namespace Noxy.NET.Test.Domain.Abstractions.Forms;

public abstract class BaseFormModelEntityAssociation(BaseEntity? entity, BaseEntity? relation) : BaseFormModelEntity(entity)
{
    [Required]
    public virtual Guid EntityID { get; set; } = entity?.ID ?? Guid.Empty;
    
    [Required]
    public virtual Guid RelationID { get; set; }= relation?.ID ?? Guid.Empty;
}
