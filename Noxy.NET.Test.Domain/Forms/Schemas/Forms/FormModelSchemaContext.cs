using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using Noxy.NET.Test.Domain.Abstractions.Forms;
using Noxy.NET.Test.Domain.Entities.Schemas;
using Noxy.NET.Test.Domain.Entities.Schemas.Junctions;

namespace Noxy.NET.Test.Domain.Forms.Schemas.Forms;

public class FormModelSchemaContext(EntitySchemaContext? entity) : BaseFormModelEntitySchemaComponent(entity)
{
    public override string APIEndpoint => "Schema/Context";

    public List<HasAction>? ActionList { get; set; } = entity?.ActionList?.Select(x => new HasAction(x)).ToList();

    public List<HasElement>? ElementList { get; set; } = entity?.ElementList?.Select(x => new HasElement(x)).ToList();

    
    [JsonConstructor]
    public FormModelSchemaContext() : this(null)
    {
    }
    
    public class HasAction
    {
        [Required]
        public required Guid ID { get; set; }
        
        [Required]
        public required Guid RelationID { get; set; }
        
        [Required]
        public required int Order { get; set; }

        [JsonConstructor]
        public HasAction()
        {
            ID = Guid.Empty;
            RelationID = Guid.Empty;
            Order = 0;
        }

        [SetsRequiredMembers]
        public HasAction(EntityJunctionSchemaContextHasAction model)
        {
            ID = model.ID;
            RelationID = model.RelationID;
            Order = model.Order;
        }
    }
    
    public class HasElement
    {
        [Required]
        public required Guid ID { get; set; }
        
        [Required]
        public required Guid RelationID { get; set; }
        
        [Required]
        public required int Order { get; set; }

        [JsonConstructor]
        public HasElement()
        {
            ID = Guid.Empty;
            RelationID = Guid.Empty;
            Order = 0;
        }

        [SetsRequiredMembers]
        public HasElement(EntityJunctionSchemaContextHasElement model)
        {
            ID = model.ID;
            RelationID = model.RelationID;
            Order = model.Order;
        }
    }
}
