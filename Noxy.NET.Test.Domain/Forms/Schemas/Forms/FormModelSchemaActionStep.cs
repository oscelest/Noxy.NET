using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Noxy.NET.Test.Domain.Abstractions.Forms;
using Noxy.NET.Test.Domain.Constants;
using Noxy.NET.Test.Domain.Entities.Schemas;

namespace Noxy.NET.Test.Domain.Forms.Schemas.Forms;

public class FormModelSchemaActionStep(EntitySchemaActionStep? entity) : BaseFormModelEntitySchemaComponent(entity)
{
    public override string APIEndpoint => "Schema/ActionStep";

    [Required]
    [DisplayName(TextConstants.LabelFormIsRepeatable)]
    [Description(TextConstants.HelpFormIsRepeatable)]
    public bool IsRepeatable { get; set; }

    [JsonConstructor]
    public FormModelSchemaActionStep() : this(null)
    {
    }
}
