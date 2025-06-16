using Noxy.NET.Test.Domain.Entities.Schemas.Discriminators;
using Noxy.NET.Test.Domain.Models;

namespace Noxy.NET.Test.Application.Interfaces.Repositories;

public interface IAssociationRepository
{
    Task ClearActionInputAttribute(Guid idEntity);
    Task<List<EntityAssociationSchemaActionInputHasAttribute>> AssociateActionInputWithAttribute(Guid idEntity, Guid idRelation, IEnumerable<string> value);
    Task<List<EntityAssociationSchemaActionInputHasAttribute>> AssociateActionInputWithAttribute(Guid idEntity, Guid idRelation, IEnumerable<int?> value);
    Task<List<EntityAssociationSchemaActionInputHasAttribute>> AssociateActionInputWithAttribute(Guid idEntity, Guid idRelation, IEnumerable<GenericUUID<EntitySchemaDynamicValue>?> list);
}
