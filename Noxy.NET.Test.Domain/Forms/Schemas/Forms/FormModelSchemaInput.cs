using System.Text.Json.Serialization;
using Noxy.NET.Test.Domain.Abstractions.Forms;
using Noxy.NET.Test.Domain.Entities.Schemas;

namespace Noxy.NET.Test.Domain.Forms.Schemas.Forms;

public class FormModelSchemaInput(EntitySchemaInput? entity = null) : BaseFormModelEntitySchema(entity)
{
    public override string APIEndpoint => "Schema/Input";
    
    [JsonConstructor]
    public FormModelSchemaInput() : this(null)
    {
    }
}
