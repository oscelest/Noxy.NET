using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Noxy.NET.Test.Persistence.Abstractions.Tables;

namespace Noxy.NET.Test.Persistence.Tables.Schemas.Junctions;

[Table(nameof(TableJunctionSchemaActionHasDynamicValueCode))]
[Index(nameof(EntityID), nameof(RelationID), IsUnique = true)]
public class TableJunctionSchemaActionHasDynamicValueCode : BaseTableJunction<TableSchemaAction, TableSchemaDynamicValueCode>;
