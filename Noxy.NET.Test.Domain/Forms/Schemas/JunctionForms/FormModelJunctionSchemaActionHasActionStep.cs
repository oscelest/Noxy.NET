using System.ComponentModel;
using Noxy.NET.Test.Domain.Abstractions.Forms;
using Noxy.NET.Test.Domain.Entities.Schemas;

namespace Noxy.NET.Test.Domain.Forms.Schemas.JunctionForms;

public class FormModelJunctionSchemaActionHasActionStep(EntitySchemaAction? entity) : BaseFormModelEntityJunction(entity)
{
    public override string APIEndpoint => "Junction/Schema/Action/ActionStep";

    [DisplayName("Action")]
    public override Guid EntityID { get; set; } = entity?.ID ?? Guid.Empty;

    [DisplayName("Action step list")]
    public override List<Guid> RelationIDList { get; set; } = entity?.ActionStepList?.Select(x => x.ID).ToList() ?? [];
}
