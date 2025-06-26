using Noxy.NET.Test.Domain.Entities.Schemas.Junctions;

namespace Noxy.NET.Test.Application.Interfaces.Repositories;

public interface IJunctionRepository
{
    Task<EntityJunctionSchemaActionStepHasActionInput> GetActionStepHasActionInputByID(Guid id);
    Task<EntityJunctionSchemaActionStepHasActionInput> Create(EntityJunctionSchemaActionStepHasActionInput entity);
    void Update(EntityJunctionSchemaActionStepHasActionInput entity);

    Task<List<EntityJunctionSchemaElementHasProperty>> RelateElementToPropertyList(Guid entityGuid, IEnumerable<Guid> listGuid);
    Task<List<EntityJunctionSchemaActionHasActionStep>> RelateActionToActionStepList(Guid entityGuid, IEnumerable<Guid> listGuid);
    Task<List<EntityJunctionSchemaActionHasDynamicValueCode>> RelateActionToDynamicValueCode(Guid entityGuid, IEnumerable<Guid> listGuid);
    Task<List<EntityJunctionSchemaActionStepHasActionInput>> RelateActionStepToActionInputList(Guid entityGuid, IEnumerable<Guid> listGuid);
    Task<List<EntityJunctionSchemaContextHasAction>> RelateContextToAction(Guid entityGuid, IEnumerable<Guid> listGuid);
    Task<List<EntityJunctionSchemaContextHasElement>> RelateContextToElement(Guid entityGuid, IEnumerable<Guid> listGuid);
}
