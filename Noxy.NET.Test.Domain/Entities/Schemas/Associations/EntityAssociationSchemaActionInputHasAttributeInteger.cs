using System.ComponentModel.DataAnnotations;
using Noxy.NET.Test.Domain.Entities.Schemas.Discriminators;

namespace Noxy.NET.Test.Domain.Entities.Schemas.Associations;

public class EntityAssociationSchemaActionInputHasAttributeInteger : EntityAssociationSchemaActionInputHasAttribute
{
    [Required]
    public required int? Value { get; set; }
}
