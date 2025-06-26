using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using Noxy.NET.Test.Domain.Abstractions.Forms;
using Noxy.NET.Test.Domain.Constants;
using Noxy.NET.Test.Domain.Entities.Schemas;
using Noxy.NET.Test.Domain.Entities.Schemas.Junctions;

namespace Noxy.NET.Test.Domain.Forms.Schemas.Forms;

public class FormModelSchemaActionStep(EntitySchemaActionStep? entity = null) : BaseFormModelEntitySchemaComponent(entity)
{
    public override string APIEndpoint => "Schema/ActionStep";

    [Required]
    [DisplayName(TextConstants.LabelFormIsRepeatable)]
    [Description(TextConstants.HelpFormIsRepeatable)]
    public bool IsRepeatable { get; set; }

    public List<HasActionInput>? ActionInputList { get; set; } = entity?.ActionInputList?.Select(x => new HasActionInput(x)).ToList();

    [JsonConstructor]
    public FormModelSchemaActionStep() : this(null)
    {
    }

    public class HasActionInput
    {
        [Required]
        public required Guid ID { get; set; }
        
        [Required]
        public required Guid RelationID { get; set; }
        
        [Required]
        public required int Order { get; set; }

        [JsonConstructor]
        public HasActionInput()
        {
            ID = Guid.Empty;
            RelationID = Guid.Empty;
            Order = 0;
        }

        [SetsRequiredMembers]
        public HasActionInput(EntityJunctionSchemaActionStepHasActionInput model)
        {
            ID = model?.ID ?? Guid.Empty;
            RelationID = model?.RelationID ?? Guid.NewGuid();
            Order = model?.Order ?? 0;
        }
    }
}
