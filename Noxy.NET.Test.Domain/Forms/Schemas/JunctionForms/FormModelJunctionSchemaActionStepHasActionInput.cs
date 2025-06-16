using System.ComponentModel;
using Noxy.NET.Test.Domain.Abstractions.Forms;
using Noxy.NET.Test.Domain.Entities.Schemas;

namespace Noxy.NET.Test.Domain.Forms.Schemas.JunctionForms;

public class FormModelJunctionSchemaActionStepHasActionInput(EntitySchemaActionStep? entity) : BaseFormModelEntityJunction(entity)
{
    public override string APIEndpoint => "Junction/Schema/ActionStep/ActionInput";

    [DisplayName("Action step")]
    public override Guid EntityID { get; set; } = entity?.ID ?? Guid.Empty;

    [DisplayName("Action input list")]
    public override List<Guid> RelationIDList { get; set; } = entity?.ActionInputList?.Select(x => x.ID).ToList() ?? [];
}
