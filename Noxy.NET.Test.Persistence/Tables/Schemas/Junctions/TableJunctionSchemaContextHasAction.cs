using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Noxy.NET.Test.Persistence.Abstractions.Tables;

namespace Noxy.NET.Test.Persistence.Tables.Schemas.Junctions;

[Table(nameof(TableJunctionSchemaContextHasAction))]
[Index(nameof(EntityID), nameof(RelationID), IsUnique = true)]
public class TableJunctionSchemaContextHasAction :BaseTableJunction<TableSchemaContext, TableSchemaAction>;
