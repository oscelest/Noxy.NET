using Noxy.NET.Test.Persistence.Abstractions.Tables;
using Noxy.NET.Test.Persistence.Tables.Schemas.Associations;

namespace Noxy.NET.Test.Persistence.Tables.Schemas.Discriminators;

public abstract class TableSchemaDynamicValue : BaseTableSchema
{
    public ICollection<TableSchemaAction>? ActionList { get; set; }
    public ICollection<TableAssociationSchemaActionInputHasAttributeDynamicValue>? ActionInputAttributeList { get; set; }
}
