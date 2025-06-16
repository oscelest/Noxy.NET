using System.ComponentModel.DataAnnotations;
using Noxy.NET.Test.Persistence.Abstractions.Tables;
using Noxy.NET.Test.Persistence.Tables.Schemas.Junctions;

namespace Noxy.NET.Test.Persistence.Tables.Schemas.Discriminators;

public abstract class TableSchemaProperty : BaseTableSchemaComponent
{
    [Required]
    [StringLength(1024)]
    public required string DefaultValue { get; set; }
    
    public ICollection<TableJunctionSchemaElementHasProperty>? ElementList { get; set; }
}
