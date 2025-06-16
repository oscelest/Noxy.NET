using System.ComponentModel;
using Noxy.NET.Test.Domain.Abstractions.Forms;
using Noxy.NET.Test.Domain.Entities.Schemas;

namespace Noxy.NET.Test.Domain.Forms.Schemas.JunctionForms;

public class FormModelJunctionSchemaContextHasAction(EntitySchemaContext? entity) : BaseFormModelEntityJunction(entity)
{
    public override string APIEndpoint => "Junction/Schema/Context/Action";

    [DisplayName("Context")]
    public override Guid EntityID { get; set; } = entity?.ID ?? Guid.Empty;

    [DisplayName("Action list")]
    public override List<Guid> RelationIDList { get; set; } = entity?.ActionList?.Select(x => x.ID).ToList() ?? [];
}
