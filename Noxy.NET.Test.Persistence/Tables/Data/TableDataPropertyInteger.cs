using System.ComponentModel.DataAnnotations.Schema;
using Noxy.NET.Test.Persistence.Tables.Data.Discriminators;

namespace Noxy.NET.Test.Persistence.Tables.Data;

[Table(nameof(TableDataPropertyInteger))]
public class TableDataPropertyInteger : TableDataProperty
{
    public required int? Value { get; set; }
}
