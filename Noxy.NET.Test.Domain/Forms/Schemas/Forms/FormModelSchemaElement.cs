using System.Text.Json.Serialization;
using Noxy.NET.Test.Domain.Abstractions.Forms;
using Noxy.NET.Test.Domain.Entities.Schemas;

namespace Noxy.NET.Test.Domain.Forms.Schemas.Forms;

public class FormModelSchemaElement(EntitySchemaElement? entity) : BaseFormModelEntitySchemaComponent(entity)
{
    public override string APIEndpoint =>  "Schema/Element";

    [JsonConstructor]
    public FormModelSchemaElement() : this(null)
    {
    }
}
