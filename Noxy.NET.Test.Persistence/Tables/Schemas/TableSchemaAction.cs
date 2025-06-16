using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Noxy.NET.Test.Persistence.Abstractions.Tables;
using Noxy.NET.Test.Persistence.Tables.Schemas.Discriminators;
using Noxy.NET.Test.Persistence.Tables.Schemas.Junctions;

namespace Noxy.NET.Test.Persistence.Tables.Schemas;

[Table(nameof(TableSchemaAction))]
[Index(nameof(SchemaID), nameof(SchemaIdentifier), IsUnique = true)]
public class TableSchemaAction : BaseTableSchemaComponent
{
    [Required]
    public TableSchemaDynamicValue? TitleDynamic { get; set; }
    public required Guid TitleDynamicID { get; set; }
    
    public ICollection<TableJunctionSchemaActionHasActionStep>? ActionStepList { get; set; }
    public ICollection<TableJunctionSchemaContextHasAction>? ContextList { get; set; }
    public ICollection<TableJunctionSchemaActionHasDynamicValueCode>? DynamicValueCodeList { get; set; }
}
