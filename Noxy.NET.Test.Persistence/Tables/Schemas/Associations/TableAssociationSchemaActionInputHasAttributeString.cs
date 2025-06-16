using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Noxy.NET.Test.Persistence.Tables.Schemas.Discriminators;

namespace Noxy.NET.Test.Persistence.Tables.Schemas.Associations;

[Table(nameof(TableAssociationSchemaActionInputHasAttributeString))]
public class TableAssociationSchemaActionInputHasAttributeString : TableAssociationSchemaActionInputHasAttribute
{
    [Required]
    public required string Value { get; set; }
}
