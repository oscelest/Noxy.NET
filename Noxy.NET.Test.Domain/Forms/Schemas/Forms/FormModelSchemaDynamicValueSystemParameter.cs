using System.Text.Json.Serialization;
using Noxy.NET.Test.Domain.Abstractions.Forms;
using Noxy.NET.Test.Domain.Entities.Schemas;

namespace Noxy.NET.Test.Domain.Forms.Schemas.Forms;

public class FormModelSchemaDynamicValueSystemParameter(EntitySchemaDynamicValueSystemParameter? entity) : BaseFormModelEntitySchemaDynamicValueParameter(entity)
{
    public override string APIEndpoint =>  "Schema/DynamicValue/SystemParameter";
    
    [JsonConstructor]
    public FormModelSchemaDynamicValueSystemParameter() : this(null)
    {
    }
}
