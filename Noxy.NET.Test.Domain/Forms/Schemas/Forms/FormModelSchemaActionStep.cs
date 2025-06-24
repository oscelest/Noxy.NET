using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Noxy.NET.Test.Domain.Abstractions.Forms;
using Noxy.NET.Test.Domain.Constants;
using Noxy.NET.Test.Domain.Entities.Schemas;
using Noxy.NET.Test.Domain.Entities.Schemas.Junctions;
using Noxy.NET.Test.Domain.Forms.Schemas.AssociationForms;

namespace Noxy.NET.Test.Domain.Forms.Schemas.Forms;

public class FormModelSchemaActionStep(EntitySchemaActionStep? entity) : BaseFormModelEntitySchemaComponent(entity)
{
    public override string APIEndpoint => "Schema/ActionStep";

    [Required]
    [DisplayName(TextConstants.LabelFormIsRepeatable)]
    [Description(TextConstants.HelpFormIsRepeatable)]
    public bool IsRepeatable { get; set; }

    public List<FormModelAssociationSchemaActionStepHasActionInput>? ActionInputList { get; set; } = GetActionInputList(entity?.ActionInputList);

    [JsonConstructor]
    public FormModelSchemaActionStep() : this(null)
    {
    }

    private static List<FormModelAssociationSchemaActionStepHasActionInput> GetActionInputList(List<EntityJunctionSchemaActionStepHasActionInput>? list)
    {
        return list?.Select(item => new FormModelAssociationSchemaActionStepHasActionInput(item.Entity, item.Relation)
            {
                Order = item.Order,
            })
            .ToList() ?? [];
    }
}
