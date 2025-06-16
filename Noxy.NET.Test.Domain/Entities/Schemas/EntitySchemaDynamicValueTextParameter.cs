using Noxy.NET.Test.Domain.Entities.Schemas.Discriminators;
using Noxy.NET.Test.Domain.Enums;

namespace Noxy.NET.Test.Domain.Entities.Schemas;

public class EntitySchemaDynamicValueTextParameter : EntitySchemaDynamicValueParameter
{
    public required TextParameterTypeEnum Type { get; set; }
}
