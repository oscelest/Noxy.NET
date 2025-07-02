using Noxy.NET.Test.Domain.Entities.Schemas.Discriminators;
using Noxy.NET.Test.Domain.Enums;

namespace Noxy.NET.Test.Domain.Entities.Schemas;

public class EntitySchemaPropertyDateTime : EntitySchemaProperty
{
    public required DateTimeTypeEnum Type { get; set; }
}
