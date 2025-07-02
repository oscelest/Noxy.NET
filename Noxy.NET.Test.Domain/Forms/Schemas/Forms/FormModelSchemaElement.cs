using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using Noxy.NET.Test.Domain.Abstractions.Forms;
using Noxy.NET.Test.Domain.Entities.Schemas;
using Noxy.NET.Test.Domain.Entities.Schemas.Junctions;

namespace Noxy.NET.Test.Domain.Forms.Schemas.Forms;

public class FormModelSchemaElement(EntitySchemaElement? entity) : BaseFormModelEntitySchemaComponent(entity)
{
    public override string APIEndpoint =>  "Schema/Element";

    [JsonConstructor]
    public FormModelSchemaElement() : this(null)
    {
    }
    
    public List<HasProperty>? PropertyList { get; set; } = entity?.PropertyList?.Select(x => new HasProperty(x)).ToList();
    
    public class HasProperty
    {
        [Required]
        public required Guid ID { get; set; }
        
        [Required]
        public required Guid RelationID { get; set; }
        
        [Required]
        public required int Order { get; set; }

        [JsonConstructor]
        public HasProperty()
        {
            ID = Guid.Empty;
            RelationID = Guid.Empty;
            Order = 0;
        }

        [SetsRequiredMembers]
        public HasProperty(EntityJunctionSchemaElementHasProperty model)
        {
            ID = model.ID;
            RelationID = model.RelationID;
            Order = model.Order;
        }
    }
}
