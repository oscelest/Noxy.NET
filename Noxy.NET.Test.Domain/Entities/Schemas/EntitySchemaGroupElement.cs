using Noxy.NET.Test.Domain.Abstractions.Entities;

namespace Noxy.NET.Test.Domain.Entities.Schemas;

public class EntitySchemaGroupElement : BaseEntitySchema
{
    public List<EntitySchemaElement>? ElementList { get; set; }
}
