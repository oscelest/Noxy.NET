using Noxy.NET.Test.Application.Interfaces;
using Noxy.NET.Test.Application.Interfaces.Services;
using Noxy.NET.Test.Domain.Entities.Schemas;
using Noxy.NET.Test.Domain.Forms.Schemas.JunctionForms;

namespace Noxy.NET.Test.Application.Services;

public class JunctionService(IUnitOfWorkFactory serviceUoWFactory) : IJunctionService
{
    public async Task<EntitySchemaAction> Relate(FormModelJunctionSchemaActionHasActionStep model)
    {
        await using IUnitOfWork uow = await serviceUoWFactory.Create();

        EntitySchemaAction result = await uow.Schema.GetSchemaActionByID(model.EntityID);
        result.ActionStepList = await uow.Junction.RelateActionToActionStepList(model.EntityID, model.RelationIDList);
        await uow.Commit();

        return result;
    }

    public async Task<EntitySchemaAction> Relate(FormModelJunctionSchemaActionHasDynamicValueCode model)
    {
        await using IUnitOfWork uow = await serviceUoWFactory.Create();

        EntitySchemaAction result = await uow.Schema.GetSchemaActionByID(model.EntityID);
        result.DynamicValueCodeList = await uow.Junction.RelateActionToDynamicValueCode(model.EntityID, model.RelationIDList);
        await uow.Commit();

        return result;
    }

    public async Task<EntitySchemaActionStep> Relate(FormModelJunctionSchemaActionStepHasActionInput model)
    {
        await using IUnitOfWork uow = await serviceUoWFactory.Create();

        EntitySchemaActionStep result = await uow.Schema.GetSchemaActionStepByID(model.EntityID);
        result.ActionInputList = await uow.Junction.RelateActionStepToActionInputList(model.EntityID, model.RelationIDList);
        await uow.Commit();

        return result;
    }

    public async Task<EntitySchemaContext> Relate(FormModelJunctionSchemaContextHasAction model)
    {
        await using IUnitOfWork uow = await serviceUoWFactory.Create();

        EntitySchemaContext result = await uow.Schema.GetSchemaContextByID(model.EntityID);
        result.ActionList = await uow.Junction.RelateContextToAction(model.EntityID, model.RelationIDList);
        await uow.Commit();

        return result;
    }

    public async Task<EntitySchemaContext> Relate(FormModelJunctionSchemaContextHasElement model)
    {
        await using IUnitOfWork uow = await serviceUoWFactory.Create();

        EntitySchemaContext result = await uow.Schema.GetSchemaContextByID(model.EntityID);
        result.ElementList = await uow.Junction.RelateContextToElement(model.EntityID, model.RelationIDList);
        await uow.Commit();

        return result;
    }

    public async Task<EntitySchemaElement> Relate(FormModelJunctionSchemaElementHasProperty model)
    {
        await using IUnitOfWork uow = await serviceUoWFactory.Create();

        EntitySchemaElement result = await uow.Schema.GetSchemaElementByID(model.EntityID);
        result.PropertyList = await uow.Junction.RelateElementToPropertyList(model.EntityID, model.RelationIDList);
        await uow.Commit();

        return result;
    }
}
