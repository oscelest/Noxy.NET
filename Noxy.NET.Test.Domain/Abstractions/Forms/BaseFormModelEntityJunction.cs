using System.ComponentModel.DataAnnotations;
using Noxy.NET.Test.Domain.Abstractions.Entities;

namespace Noxy.NET.Test.Domain.Abstractions.Forms;

public abstract class BaseFormModelEntityJunction(BaseEntity? entity) : BaseFormModelEntity(entity)
{
    [Required]
    public abstract Guid EntityID { get; set; }
    
    [Required]
    public abstract List<Guid> RelationIDList { get; set; }
}
