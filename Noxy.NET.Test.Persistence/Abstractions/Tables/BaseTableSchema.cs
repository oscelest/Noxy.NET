using System.ComponentModel.DataAnnotations;
using Noxy.NET.Test.Persistence.Tables.Schemas;

namespace Noxy.NET.Test.Persistence.Abstractions.Tables;

public abstract class BaseTableSchema : BaseTableTemplate
{
    [Required]
    [StringLength(64)]
    public required string SchemaIdentifier { get; set; }
    
    [Required]
    public TableSchema? Schema { get; set; }
    public required Guid SchemaID { get; set; }
}
