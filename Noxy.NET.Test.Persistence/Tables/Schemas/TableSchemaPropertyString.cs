using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Noxy.NET.Test.Persistence.Tables.Schemas.Discriminators;

namespace Noxy.NET.Test.Persistence.Tables.Schemas;

[Table(nameof(TableSchemaPropertyString))]
[Index(nameof(SchemaID), nameof(SchemaIdentifier), IsUnique = true)]
public class TableSchemaPropertyString : TableSchemaProperty
{
}
