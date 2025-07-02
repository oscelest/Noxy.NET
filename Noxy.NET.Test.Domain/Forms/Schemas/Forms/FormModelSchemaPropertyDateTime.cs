using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Noxy.NET.Test.Domain.Abstractions.Forms;
using Noxy.NET.Test.Domain.Constants;
using Noxy.NET.Test.Domain.Entities.Schemas;
using Noxy.NET.Test.Domain.Enums;

namespace Noxy.NET.Test.Domain.Forms.Schemas.Forms;

public class FormModelSchemaPropertyDateTime(EntitySchemaPropertyDateTime? entity) : BaseFormModelEntitySchemaComponent(entity)
{
    public override string APIEndpoint => "Schema/Property/DateTime";

    [Required]
    [DisplayName(TextConstants.LabelFormDefaultValue)]
    [Description(TextConstants.HelpFormDefaultValue)]
    public string DefaultValue { get; set; } = entity?.DefaultValue ?? string.Empty;

    [Required]
    public DateTimeTypeEnum Type { get; set; } = entity?.Type ?? DateTimeTypeEnum.Date;

    
    [JsonConstructor]
    public FormModelSchemaPropertyDateTime() : this(null)
    {
    }
}
