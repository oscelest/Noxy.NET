using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Noxy.NET.Test.Domain.Abstractions.Forms;
using Noxy.NET.Test.Domain.Constants;
using Noxy.NET.Test.Domain.Entities.Schemas;

namespace Noxy.NET.Test.Domain.Forms.Schemas.Forms;

public class FormModelSchemaDynamicValueCode(EntitySchemaDynamicValueCode? entity) : BaseFormModelEntitySchema(entity)
{
    public override string APIEndpoint => "Schema/DynamicValue/Code";

    [Required]
    [DisplayName(TextConstants.FormEntitySchemaLabelDynamicValueCodeValue)]
    [Description(TextConstants.FormEntitySchemaHelpDynamicValueCodeValue)]
    public string Value { get; set; } = entity?.Value ?? string.Empty;

    [Required]
    [DisplayName(TextConstants.FormEntitySchemaLabelDynamicValueCodeIsAsynchronous)]
    [Description(TextConstants.FormEntitySchemaHelpDynamicValueCodeIsAsynchronous)]
    public bool IsAsynchronous { get; set; } = entity?.IsAsynchronous ?? true;

    [JsonConstructor]
    public FormModelSchemaDynamicValueCode() : this(null)
    {
    }
}
