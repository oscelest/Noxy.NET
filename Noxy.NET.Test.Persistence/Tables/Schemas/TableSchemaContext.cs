using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Noxy.NET.Test.Persistence.Abstractions.Tables;
using Noxy.NET.Test.Persistence.Tables.Schemas.Junctions;

namespace Noxy.NET.Test.Persistence.Tables.Schemas;

[Table(nameof(TableSchemaContext))]
[Index(nameof(SchemaID), nameof(SchemaIdentifier), IsUnique = true)]
public class TableSchemaContext : BaseTableSchemaComponent
{
    public ICollection<TableJunctionSchemaContextHasAction>? ActionList { get; set; }
    public ICollection<TableJunctionSchemaContextHasElement>? ElementList { get; set; }
}
