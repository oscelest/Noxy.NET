using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Noxy.NET.Test.Domain.Constants;
using Noxy.NET.Test.Domain.Entities.Schemas.Discriminators;

namespace Noxy.NET.Test.Domain.Abstractions.Forms;

public abstract class BaseFormModelEntitySchemaDynamicValueParameter(EntitySchemaDynamicValueParameter? entity = null) : BaseFormModelEntitySchema(entity)
{
    [Required]
    [DisplayName(TextConstants.FormEntitySchemaLabelDynamicValueParameterIsApprovalRequired)]
    [Description(TextConstants.FormEntitySchemaHelpDynamicValueParameterIsApprovalRequired)]
    public bool IsApprovalRequired { get; set; } = entity?.IsApprovalRequired ?? false;
}
