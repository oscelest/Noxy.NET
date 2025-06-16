using System.ComponentModel.DataAnnotations;

namespace Noxy.NET.Test.Persistence.Tables.Schemas.Discriminators;

public abstract class TableSchemaDynamicValueParameter : TableSchemaDynamicValue
{
    [Required]
    public required bool IsApprovalRequired { get; set; } 
}
