using System.ComponentModel;
using Noxy.NET.Test.Domain.Abstractions.Forms;
using Noxy.NET.Test.Domain.Entities.Schemas;

namespace Noxy.NET.Test.Domain.Forms.Schemas.JunctionForms;

public class FormModelJunctionSchemaElementHasProperty(EntitySchemaElement? entity) : BaseFormModelEntityJunction(entity)
{
    public override string APIEndpoint => "Junction/Schema/Element/Property";

    [DisplayName("Element")]
    public override Guid EntityID { get; set; } = entity?.ID ?? Guid.Empty;

    [DisplayName("Property list")]
    public override List<Guid> RelationIDList { get; set; } = entity?.PropertyList?.Select(x => x.ID).ToList() ?? [];
}
