using System.ComponentModel.DataAnnotations;

namespace Noxy.NET.Test.Persistence.Abstractions.Tables;

public abstract class BaseTableSchemaComponent : BaseTableSchema
{
    [Required]
    [MaxLength(64)]
    public required string Title { get; set; }

    [MaxLength(1024)]
    public required string Description { get; set; }
}
