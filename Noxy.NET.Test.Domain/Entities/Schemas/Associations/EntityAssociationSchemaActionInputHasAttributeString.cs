using System.ComponentModel.DataAnnotations;
using Noxy.NET.Test.Domain.Entities.Schemas.Discriminators;

namespace Noxy.NET.Test.Domain.Entities.Schemas.Associations;

public class EntityAssociationSchemaActionInputHasAttributeString : EntityAssociationSchemaActionInputHasAttribute
{
    [Required]
    public required string Value { get; set; }
}
