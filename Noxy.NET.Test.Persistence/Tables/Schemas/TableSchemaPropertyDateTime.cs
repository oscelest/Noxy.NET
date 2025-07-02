using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Noxy.NET.Test.Domain.Enums;
using Noxy.NET.Test.Persistence.Tables.Schemas.Discriminators;

namespace Noxy.NET.Test.Persistence.Tables.Schemas;

[Table(nameof(TableSchemaPropertyDateTime))]
[Index(nameof(SchemaID), nameof(SchemaIdentifier), IsUnique = true)]
public class TableSchemaPropertyDateTime : TableSchemaProperty
{
    [Required]
    public required DateTimeTypeEnum Type { get; set; }
}