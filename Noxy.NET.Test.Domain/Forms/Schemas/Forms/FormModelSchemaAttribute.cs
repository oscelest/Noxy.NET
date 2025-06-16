using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Noxy.NET.Test.Domain.Abstractions.Forms;
using Noxy.NET.Test.Domain.Entities.Schemas;
using Noxy.NET.Test.Domain.Enums;

namespace Noxy.NET.Test.Domain.Forms.Schemas.Forms;

public class FormModelSchemaAttribute(EntitySchemaAttribute? entity) : BaseFormModelEntitySchema(entity)
{
    public override string APIEndpoint => "Schema/Attribute";

    [Required]
    public AttributeTypeEnum Type { get; set; } = entity?.Type ?? AttributeTypeEnum.String;

    [Required]
    public bool IsList { get; set; } = entity?.IsList ?? false;

    [JsonConstructor]
    public FormModelSchemaAttribute() : this(null)
    {
    }
}
