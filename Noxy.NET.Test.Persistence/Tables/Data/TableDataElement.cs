using System.ComponentModel.DataAnnotations.Schema;
using Noxy.NET.Test.Persistence.Abstractions.Tables;
using Noxy.NET.Test.Persistence.Tables.Data.Discriminators;

namespace Noxy.NET.Test.Persistence.Tables.Data;

[Table(nameof(TableDataElement))]
public class TableDataElement : BaseTableData
{
    public ICollection<TableDataProperty>? PropertyList { get; set; }
}
