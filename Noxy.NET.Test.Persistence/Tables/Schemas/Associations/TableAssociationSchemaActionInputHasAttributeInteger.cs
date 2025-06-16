using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Noxy.NET.Test.Persistence.Tables.Schemas.Discriminators;

namespace Noxy.NET.Test.Persistence.Tables.Schemas.Associations;

[Table(nameof(TableAssociationSchemaActionInputHasAttributeInteger))]
public class TableAssociationSchemaActionInputHasAttributeInteger : TableAssociationSchemaActionInputHasAttribute
{
    [Required]
    public required int? Value { get; set; }
}
