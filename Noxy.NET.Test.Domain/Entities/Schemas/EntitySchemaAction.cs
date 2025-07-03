using System.Text.Json.Serialization;
using Noxy.NET.Test.Domain.Abstractions.Entities;
using Noxy.NET.Test.Domain.Entities.Schemas.Junctions;
using Noxy.NET.Test.Domain.ViewModels;

namespace Noxy.NET.Test.Domain.Entities.Schemas;

public class EntitySchemaAction : BaseEntitySchemaComponent
{
    public List<EntityJunctionSchemaActionHasActionStep>? ActionStepList { get; set; }
    public List<EntityJunctionSchemaActionHasDynamicValueCode>? DynamicValueCodeList { get; set; }

    [JsonIgnore]
    public List<EntityJunctionSchemaContextHasAction>? ContextList { get; set; }
}
