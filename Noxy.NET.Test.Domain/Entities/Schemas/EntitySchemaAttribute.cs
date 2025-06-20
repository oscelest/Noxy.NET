using System.Text.Json.Serialization;
using Noxy.NET.Test.Domain.Abstractions.Entities;
using Noxy.NET.Test.Domain.Entities.Schemas.Discriminators;
using Noxy.NET.Test.Domain.Entities.Schemas.Junctions;
using Noxy.NET.Test.Domain.Enums;

namespace Noxy.NET.Test.Domain.Entities.Schemas;

public class EntitySchemaAttribute : BaseEntitySchema
{
    public required AttributeTypeEnum Type { get; set; }
    public required bool IsValueList { get; set; }

    [JsonIgnore]
    public List<EntityJunctionSchemaInputHasAttribute>? InputList { get; set; }
    [JsonIgnore]
    public List<EntityAssociationSchemaActionInputHasAttribute.Discriminator>? ActionInputList { get; set; }

}
