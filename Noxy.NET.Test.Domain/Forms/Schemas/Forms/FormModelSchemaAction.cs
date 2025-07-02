using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using Noxy.NET.Test.Domain.Abstractions.Forms;
using Noxy.NET.Test.Domain.Entities.Schemas;
using Noxy.NET.Test.Domain.Entities.Schemas.Junctions;

namespace Noxy.NET.Test.Domain.Forms.Schemas.Forms;

public class FormModelSchemaAction(EntitySchemaAction? entity = null) : BaseFormModelEntitySchemaComponent(entity)
{
    public override string APIEndpoint => "Schema/Action";
    
    [Required]
    public Guid TitleDynamicID { get; set; } = entity?.TitleDynamicID ?? Guid.NewGuid();
    
    public List<HasActionStep>? ActionStepList { get; set; } = entity?.ActionStepList?.Select(x => new HasActionStep(x)).ToList();

    [JsonConstructor]
    public FormModelSchemaAction() : this(null)
    {
    }
    
    public class HasActionStep
    {
        [Required]
        public required Guid ID { get; set; }
        
        [Required]
        public required Guid RelationID { get; set; }
        
        [Required]
        public required int Order { get; set; }

        [JsonConstructor]
        public HasActionStep()
        {
            ID = Guid.Empty;
            RelationID = Guid.Empty;
            Order = 0;
        }

        [SetsRequiredMembers]
        public HasActionStep(EntityJunctionSchemaActionHasActionStep model)
        {
            ID = model.ID;
            RelationID = model.RelationID;
            Order = model.Order;
        }
    }
}
