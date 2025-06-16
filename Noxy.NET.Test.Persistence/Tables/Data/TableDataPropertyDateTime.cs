using System.ComponentModel.DataAnnotations.Schema;
using Noxy.NET.Test.Persistence.Tables.Data.Discriminators;

namespace Noxy.NET.Test.Persistence.Tables.Data;

[Table(nameof(TableDataPropertyDateTime))]
public class TableDataPropertyDateTime : TableDataProperty
{
    public required DateTime? Value { get; set; }
}
