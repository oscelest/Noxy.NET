using System.ComponentModel;
using Noxy.NET.Test.Domain.Abstractions.Forms;
using Noxy.NET.Test.Domain.Entities.Schemas;

namespace Noxy.NET.Test.Domain.Forms.Schemas.JunctionForms;

public class FormModelJunctionSchemaActionHasDynamicValueCode(EntitySchemaAction? entity) : BaseFormModelEntityJunction(entity)
{
    public override string APIEndpoint => "Junction/Schema/Action/DynamicValueCode";

    [DisplayName("Action")]
    public override Guid EntityID { get; set; } = entity?.ID ?? Guid.Empty;

    [DisplayName("Dynamic value code list")]
    public override List<Guid> RelationIDList { get; set; } = entity?.DynamicValueCodeList?.Select(x => x.ID).ToList() ?? [];
}
