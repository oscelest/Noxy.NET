using Noxy.NET.Test.Domain.Entities.Schemas.Discriminators;
using Noxy.NET.Test.Domain.Forms.Schemas.AssociationForms;

namespace Noxy.NET.Test.Application.Interfaces.Services;

public interface IAssociationService
{
    Task<List<EntityAssociationSchemaActionInputHasAttribute>> Associate(FormModelAssociationSchemaActionInputHasAttribute model);
}
