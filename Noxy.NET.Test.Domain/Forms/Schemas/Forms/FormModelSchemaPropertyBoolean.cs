using System.ComponentModel;
using System.Text.Json.Serialization;
using Noxy.NET.Test.Domain.Abstractions.Forms;
using Noxy.NET.Test.Domain.Constants;
using Noxy.NET.Test.Domain.Entities.Schemas;

namespace Noxy.NET.Test.Domain.Forms.Schemas.Forms;

public class FormModelSchemaPropertyBoolean(EntitySchemaPropertyBoolean? entity) : BaseFormModelEntitySchemaComponent(entity)
{
    public override string APIEndpoint => "Schema/Property/Boolean";

    [DisplayName(TextConstants.FormEntitySchemaLabelPropertyDefaultValue)]
    [Description(TextConstants.FormEntitySchemaHelpPropertyDefaultValue)]
    public string DefaultValue { get; set; } = entity?.DefaultValue ?? string.Empty;
    
    [JsonConstructor]
    public FormModelSchemaPropertyBoolean() : this(null)
    {
    }
}
