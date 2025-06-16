using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Noxy.NET.Test.Persistence.Abstractions.Tables;
using Noxy.NET.Test.Persistence.Tables.Schemas.Junctions;

namespace Noxy.NET.Test.Persistence.Tables.Schemas;

[Table(nameof(TableSchemaActionStep))]
[Index(nameof(SchemaID), nameof(SchemaIdentifier), IsUnique = true)]
public class TableSchemaActionStep : BaseTableSchemaComponent
{
    [Required]
    public bool IsRepeatable { get; set; }
    
    public ICollection<TableJunctionSchemaActionHasActionStep>? ActionList { get; set; }
    public ICollection<TableJunctionSchemaActionStepHasActionInput>? ActionInputList { get; set; }
}
