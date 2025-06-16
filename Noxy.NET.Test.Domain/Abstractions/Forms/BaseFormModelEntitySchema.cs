using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Noxy.NET.Test.Domain.Abstractions.Entities;
using Noxy.NET.Test.Domain.Attributes;
using Noxy.NET.Test.Domain.Constants;

namespace Noxy.NET.Test.Domain.Abstractions.Forms;

public abstract class BaseFormModelEntitySchema(BaseEntitySchema? entity = null) : BaseFormModelEntityTemplate(entity)
{
    [Required]
    [MinLength(3), MaxLength(64)]
    [IdentifierValidation]
    [DisplayName(TextConstants.FormEntitySchemaLabelSchemaIdentifier)]
    [Description(TextConstants.FormEntitySchemaHelpSchemaIdentifier)]
    public string SchemaIdentifier { get; set; } = entity?.SchemaIdentifier ?? string.Empty;
    
    [Required]
    public required Guid SchemaID { get; set; }
    
}
