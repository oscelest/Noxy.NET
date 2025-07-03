using System.Text.Json.Serialization;
using Noxy.NET.Test.Domain.Abstractions.Entities;
using Noxy.NET.Test.Domain.Entities.Schemas.Discriminators;
using Noxy.NET.Test.Domain.Entities.Schemas.Junctions;
using Noxy.NET.Test.Domain.ViewModels;

namespace Noxy.NET.Test.Domain.Entities.Schemas;

public class EntitySchemaActionInput : BaseEntitySchemaComponent
{
    public EntitySchemaInput? Input { get; set; }
    public required Guid InputID { get; set; }
    
    public List<EntityAssociationSchemaActionInputHasAttribute.Discriminator>? AttributeList { get; set; }
    
    [JsonIgnore]
    public List<EntityJunctionSchemaActionStepHasActionInput>? ActionStepList { get; set; }
}
    