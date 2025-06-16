using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Noxy.NET.Test.Domain.Abstractions.Forms;
using Noxy.NET.Test.Domain.Entities.Schemas;

namespace Noxy.NET.Test.Domain.Forms.Schemas.Forms;

public class FormModelSchemaAction(EntitySchemaAction? entity = null) : BaseFormModelEntitySchemaComponent(entity)
{
    public override string APIEndpoint => "Schema/Action";
    
    [Required]
    public Guid TitleDynamicID { get; set; }
    
    [JsonConstructor]
    public FormModelSchemaAction() : this(null)
    {
    }
}
