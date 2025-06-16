using System.Text.Json.Serialization;
using Noxy.NET.Test.Domain.Abstractions.Forms;
using Noxy.NET.Test.Domain.Entities.Schemas;

namespace Noxy.NET.Test.Domain.Forms.Schemas.Forms;

public class FormModelSchema(EntitySchema? entity = null) : BaseFormModelEntityTemplate(entity)
{
    public override string APIEndpoint => "Template/Schema";

    [JsonConstructor]
    public FormModelSchema() : this(null)
    {
    }
}
