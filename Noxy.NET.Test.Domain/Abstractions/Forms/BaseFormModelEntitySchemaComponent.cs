using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Noxy.NET.Test.Domain.Abstractions.Entities;
using Noxy.NET.Test.Domain.Constants;

namespace Noxy.NET.Test.Domain.Abstractions.Forms;

public abstract class BaseFormModelEntitySchemaComponent(BaseEntitySchemaComponent? entity) : BaseFormModelEntitySchema(entity)
{
    [Required]
    [MinLength(3), MaxLength(64)]
    [DisplayName(TextConstants.FormEntitySchemaLabelTitle)]
    [Description(TextConstants.FormEntitySchemaHelpTitle)]
    public string Title { get; set; } = entity?.Title ?? string.Empty;

    [MaxLength(1024)]
    [DisplayName(TextConstants.FormEntitySchemaLabelDescription)]
    [Description(TextConstants.FormEntitySchemaHelpDescription)]
    public string Description { get; set; } = entity?.Description ?? string.Empty;
}
