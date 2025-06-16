using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Noxy.NET.Test.Persistence.Abstractions.Tables;

namespace Noxy.NET.Test.Persistence.Tables.Authentication;

[Table(nameof(TableAuthentication))]
public class TableAuthentication : BaseTable
{
    [Required]
    public required byte[] Salt { get; set; }

    [Required]
    public required byte[] Hash { get; set; }
    
    [Required]
    public Guid UserID { get; set; }
    public TableUser? User { get; set; }
}
