using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using Noxy.NET.Test.Domain.Abstractions.Forms;
using Noxy.NET.Test.Domain.Entities.Schemas;
using Noxy.NET.Test.Domain.Entities.Schemas.Junctions;

namespace Noxy.NET.Test.Domain.Forms.Schemas.AssociationForms;

public class FormModelAssociationSchemaActionStepHasActionInput : BaseFormModelEntityAssociation
{
    public override string APIEndpoint =>  "Schema/ActionStep/ActionInput";

    [Required]
    public required int Order { get; init; }

    [JsonConstructor]
    public FormModelAssociationSchemaActionStepHasActionInput() : base(null)
    {
    }

    [SetsRequiredMembers]
    public FormModelAssociationSchemaActionStepHasActionInput(EntityJunctionSchemaActionStepHasActionInput entity) : base(entity)
    {
        Order = entity.Order;
    }

    public FormModelAssociationSchemaActionStepHasActionInput(EntitySchemaActionStep? entity, EntitySchemaActionInput? relation) : base(entity, relation)
    {
    }
}
