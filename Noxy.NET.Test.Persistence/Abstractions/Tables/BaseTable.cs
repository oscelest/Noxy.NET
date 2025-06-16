using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Noxy.NET.Test.Persistence.Abstractions.Tables;

[PrimaryKey(nameof(ID))]
[Index(nameof(TimeCreated))]
public abstract class BaseTable
{
    public Guid ID { get; init; } = Guid.CreateVersion7();
    
    [Required]
    public DateTime TimeCreated { get; set; } = DateTime.UtcNow;
}
