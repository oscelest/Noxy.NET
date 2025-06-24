using System.ComponentModel.DataAnnotations;
using Noxy.NET.Test.Domain.Abstractions.Forms;
using Noxy.NET.Test.Domain.Entities.Schemas;

namespace Noxy.NET.Test.Domain.Forms.Schemas.AssociationForms;

public class FormModelAssociationSchemaActionStepHasActionInput(EntitySchemaActionStep? entity, EntitySchemaActionInput? relation) : BaseFormModelEntityAssociation(entity, relation)
{
    public override string APIEndpoint => throw new InvalidOperationException();

    [Required]
    public int Order { get; set; } = 0;
}
