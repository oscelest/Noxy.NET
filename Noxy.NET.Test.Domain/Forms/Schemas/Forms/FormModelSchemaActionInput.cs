using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Noxy.NET.Test.Domain.Abstractions.Forms;
using Noxy.NET.Test.Domain.Constants;
using Noxy.NET.Test.Domain.Entities.Schemas;
using Noxy.NET.Test.Domain.Forms.Schemas.AssociationForms;

namespace Noxy.NET.Test.Domain.Forms.Schemas.Forms;

public class FormModelSchemaActionInput(EntitySchemaActionInput? entity) : BaseFormModelEntitySchemaComponent(entity)
{
    public override string APIEndpoint => "Schema/ActionInput";

    [Required]
    [DisplayName(TextConstants.LabelFormInputID)]
    [Description(TextConstants.HelpFormInputID)]
    public Guid InputID { get; set; } = entity?.InputID ?? Guid.NewGuid();

    public List<FormModelAssociationSchemaActionInputHasAttribute.Discriminator>? AttributeList { get; set; }
    
    [JsonConstructor]
    public FormModelSchemaActionInput() : this(null)
    {
    }
}
