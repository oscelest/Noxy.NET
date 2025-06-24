using System.Text.Json.Serialization;
using Noxy.NET.Test.Domain.Abstractions.Forms;
using Noxy.NET.Test.Domain.Entities.Schemas;

namespace Noxy.NET.Test.Domain.Forms.Schemas.Forms;

public class FormModelSchemaDynamicValueStyleParameter(EntitySchemaDynamicValueStyleParameter? entity) : BaseFormModelEntitySchemaDynamicValueParameter(entity)
{
    public override string APIEndpoint =>  "Schema/DynamicValue/StyleParameter";
    
    [JsonConstructor]
    public FormModelSchemaDynamicValueStyleParameter() : this(null)
    {
    }
}
