using System.ComponentModel.DataAnnotations.Schema;
using Noxy.NET.Test.Persistence.Abstractions.Tables;

namespace Noxy.NET.Test.Persistence.Tables.Data;

[Table(nameof(TableDataTextParameter))]
public class TableDataTextParameter : BaseTableDataParameter;
