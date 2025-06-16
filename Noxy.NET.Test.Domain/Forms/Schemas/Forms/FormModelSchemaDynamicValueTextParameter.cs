using System.Text.Json.Serialization;
using Noxy.NET.Test.Domain.Abstractions.Forms;
using Noxy.NET.Test.Domain.Entities.Schemas;
using Noxy.NET.Test.Domain.Enums;

namespace Noxy.NET.Test.Domain.Forms.Schemas.Forms;

public class FormModelSchemaDynamicValueTextParameter(EntitySchemaDynamicValueTextParameter? entity) : BaseFormModelEntitySchemaDynamicValueParameter(entity)
{
    public override string APIEndpoint =>  "Schema/DynamicValue/Code";

    public TextParameterTypeEnum Type { get; set; } = entity?.Type ?? TextParameterTypeEnum.Line;
    
    [JsonConstructor]
    public FormModelSchemaDynamicValueTextParameter() : this(null)
    {
    }
}
