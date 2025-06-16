using System.ComponentModel;
using System.Text.Json.Serialization;
using Noxy.NET.Test.Domain.Constants;
using Noxy.NET.Test.Domain.Entities.Schemas;

namespace Noxy.NET.Test.Domain.Abstractions.Entities;

public class BaseEntitySchema : BaseEntityTemplate
{
    [DisplayName(TextConstants.FormEntitySchemaLabelSchemaIdentifier)]
    public required string SchemaIdentifier { get; set; }
    
    [JsonIgnore]
    public EntitySchema? Schema { get; set; }
    public required Guid SchemaID { get; set; }
}
