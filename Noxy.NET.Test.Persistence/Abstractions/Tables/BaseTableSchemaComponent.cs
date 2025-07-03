using System.ComponentModel.DataAnnotations;
using Noxy.NET.Test.Persistence.Tables.Schemas.Discriminators;

namespace Noxy.NET.Test.Persistence.Abstractions.Tables;

public abstract class BaseTableSchemaComponent : BaseTableSchema
{
    [Required]
    public TableSchemaDynamicValue? TitleDynamic { get; set; }
    public required Guid TitleDynamicID { get; set; }

    [Required]
    public TableSchemaDynamicValue? DescriptionDynamic { get; set; }
    public required Guid DescriptionDynamicID { get; set; }
}
