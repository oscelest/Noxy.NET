using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Noxy.NET.Test.Domain.Enums;
using Noxy.NET.Test.Persistence.Abstractions.Tables;
using Noxy.NET.Test.Persistence.Tables.Schemas.Junctions;

namespace Noxy.NET.Test.Persistence.Tables.Schemas;

[Table(nameof(TableSchemaAttribute))]
[Index(nameof(SchemaID), nameof(SchemaIdentifier), IsUnique = true)]
public class TableSchemaAttribute : BaseTableSchema
{
    [Required]
    public required AttributeTypeEnum Type { get; set; }
    
    [Required]
    public required bool IsList { get; set; }
    
    public ICollection<TableJunctionSchemaInputHasAttribute>? InputList { get; set; }
}
