using System.ComponentModel;
using Noxy.NET.Test.Domain.Abstractions.Forms;
using Noxy.NET.Test.Domain.Entities.Schemas;

namespace Noxy.NET.Test.Domain.Forms.Schemas.JunctionForms;

public class FormModelJunctionSchemaContextHasElement(EntitySchemaContext? entity) : BaseFormModelEntityJunction(entity)
{
    public override string APIEndpoint => "Junction/Schema/Context/Element";

    [DisplayName("Context")]
    public override Guid EntityID { get; set; } = entity?.ID ?? Guid.Empty;

    [DisplayName("Element list")]
    public override List<Guid> RelationIDList { get; set; } = entity?.ElementList?.Select(x => x.ID).ToList() ?? [];
}
