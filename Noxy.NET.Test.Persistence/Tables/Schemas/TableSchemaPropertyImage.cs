using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Noxy.NET.Test.Persistence.Tables.Schemas.Discriminators;

namespace Noxy.NET.Test.Persistence.Tables.Schemas;

[Table(nameof(TableSchemaPropertyImage))]
[Index(nameof(SchemaID), nameof(SchemaIdentifier), IsUnique = true)]
public class TableSchemaPropertyImage : TableSchemaProperty
{
    public TableSchemaDynamicValue? WidthDynamic { get; set; }
    public Guid? WidthDynamicID { get; set; }

    public TableSchemaDynamicValue? HeightDynamic { get; set; }
    public Guid? HeightDynamicID { get; set; }
    
    [Required]
    public required string AllowedExtensions { get; set; }
}