using System.ComponentModel.DataAnnotations.Schema;
using Noxy.NET.Test.Persistence.Tables.Data.Discriminators;

namespace Noxy.NET.Test.Persistence.Tables.Data;

[Table(nameof(TableDataPropertyImage))]
public class TableDataPropertyImage : TableDataProperty
{
    public required string Value { get; set; }
}
