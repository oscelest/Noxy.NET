using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Noxy.NET.Test.Persistence.Tables.Schemas.Discriminators;

namespace Noxy.NET.Test.Persistence.Tables.Schemas.Associations;

[Table(nameof(TableAssociationSchemaActionInputHasAttributeDynamicValue))]
public class TableAssociationSchemaActionInputHasAttributeDynamicValue : TableAssociationSchemaActionInputHasAttribute
{
    [Required]
    public TableSchemaDynamicValue? Value { get; set; }
    public required Guid? ValueID { get; set; }
}
