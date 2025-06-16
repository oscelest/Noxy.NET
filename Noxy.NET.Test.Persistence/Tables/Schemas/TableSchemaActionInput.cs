using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Noxy.NET.Test.Persistence.Abstractions.Tables;
using Noxy.NET.Test.Persistence.Tables.Schemas.Discriminators;
using Noxy.NET.Test.Persistence.Tables.Schemas.Junctions;

namespace Noxy.NET.Test.Persistence.Tables.Schemas;

[Table(nameof(TableSchemaActionInput))]
[Index(nameof(SchemaID), nameof(SchemaIdentifier), IsUnique = true)]
public class TableSchemaActionInput : BaseTableSchemaComponent
{
    [Required]
    public TableSchemaInput? Input { get; set; }
    public required Guid InputID { get; set; }

    public ICollection<TableJunctionSchemaActionStepHasActionInput>? ActionStepList { get; set; }
    public ICollection<TableAssociationSchemaActionInputHasAttribute>? AttributeList { get; set; }
}
