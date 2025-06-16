using System.ComponentModel.DataAnnotations.Schema;
using Noxy.NET.Test.Persistence.Tables.Data.Discriminators;

namespace Noxy.NET.Test.Persistence.Tables.Data;

[Table(nameof(TableDataPropertyBoolean))]
public class TableDataPropertyBoolean : TableDataProperty
{
    public required bool? Value { get; set; }
}
