using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Noxy.NET.Test.Application.Interfaces.Repositories;
using Noxy.NET.Test.Domain.Entities.Schemas.Junctions;
using Noxy.NET.Test.Persistence.Abstractions;
using Noxy.NET.Test.Persistence.Abstractions.Tables;
using Noxy.NET.Test.Persistence.Interfaces.Services;
using Noxy.NET.Test.Persistence.Tables.Schemas;
using Noxy.NET.Test.Persistence.Tables.Schemas.Discriminators;
using Noxy.NET.Test.Persistence.Tables.Schemas.Junctions;

namespace Noxy.NET.Test.Persistence.Repositories;

public class JunctionRepository(DataContext context, IEntityToTableMapper mapperE2T, ITableToEntityMapper mapperT2E) : BaseRepository(context, mapperE2T, mapperT2E), IJunctionRepository
{
    public async Task<EntityJunctionSchemaActionStepHasActionInput> GetActionStepHasActionInputByID(Guid id)
    {
        TableJunctionSchemaActionStepHasActionInput result = await Context.SchemaActionStepHasActionInput.SingleAsync(x => x.ID == id);
        return mapperT2E.Map(result);
    }

    public async Task<EntityJunctionSchemaActionStepHasActionInput> Create(EntityJunctionSchemaActionStepHasActionInput entity)
    {
        EntityEntry<TableJunctionSchemaActionStepHasActionInput> result = await Context.SchemaActionStepHasActionInput.AddAsync(mapperE2T.Map(entity));
        return mapperT2E.Map(result.Entity);
    }

    public void Update(EntityJunctionSchemaActionStepHasActionInput entity)
    {
        Context.SchemaActionStepHasActionInput.Update(mapperE2T.Map(entity));
    }

    public async Task<List<EntityJunctionSchemaElementHasProperty>> RelateElementToPropertyList(Guid entityGuid, IEnumerable<Guid> listGuid)
    {
        List<TableJunctionSchemaElementHasProperty> list = await Relate<TableJunctionSchemaElementHasProperty, TableSchemaElement, TableSchemaProperty>(entityGuid, listGuid, (x, y) => new() { EntityID = x, RelationID = y, Order = 0 });
        return list.Select(MapperT2E.Map).ToList();
    }

    public async Task<List<EntityJunctionSchemaActionHasActionStep>> RelateActionToActionStepList(Guid entityGuid, IEnumerable<Guid> listGuid)
    {
        List<TableJunctionSchemaActionHasActionStep> list = await Relate<TableJunctionSchemaActionHasActionStep, TableSchemaAction, TableSchemaActionStep>(entityGuid, listGuid, (x, y) => new() { EntityID = x, RelationID = y, Order = 0 });
        return list.Select(MapperT2E.Map).ToList();
    }

    public async Task<List<EntityJunctionSchemaActionHasDynamicValueCode>> RelateActionToDynamicValueCode(Guid entityGuid, IEnumerable<Guid> listGuid)
    {
        List<TableJunctionSchemaActionHasDynamicValueCode> list = await Relate<TableJunctionSchemaActionHasDynamicValueCode, TableSchemaAction, TableSchemaDynamicValueCode>(entityGuid, listGuid, (x, y) => new() { EntityID = x, RelationID = y, Order = 0 });
        return list.Select(MapperT2E.Map).ToList();
    }

    public async Task<List<EntityJunctionSchemaActionStepHasActionInput>> RelateActionStepToActionInputList(Guid entityGuid, IEnumerable<Guid> listGuid)
    {
        List<TableJunctionSchemaActionStepHasActionInput> list = await Relate<TableJunctionSchemaActionStepHasActionInput, TableSchemaActionStep, TableSchemaActionInput>(entityGuid, listGuid, (x, y) => new() { EntityID = x, RelationID = y, Order = 0 });
        return list.Select(MapperT2E.Map).ToList();
    }

    public async Task<List<EntityJunctionSchemaContextHasAction>> RelateContextToAction(Guid entityGuid, IEnumerable<Guid> listGuid)
    {
        List<TableJunctionSchemaContextHasAction> list = await Relate<TableJunctionSchemaContextHasAction, TableSchemaContext, TableSchemaAction>(entityGuid, listGuid, (x, y) => new() { EntityID = x, RelationID = y });
        return list.Select(MapperT2E.Map).ToList();
    }

    public async Task<List<EntityJunctionSchemaContextHasElement>> RelateContextToElement(Guid entityGuid, IEnumerable<Guid> listGuid)
    {
        List<TableJunctionSchemaContextHasElement> list = await Relate<TableJunctionSchemaContextHasElement, TableSchemaContext, TableSchemaElement>(entityGuid, listGuid, (x, y) => new() { EntityID = x, RelationID = y });
        return list.Select(MapperT2E.Map).ToList();
    }

    private async Task<List<TJunction>> Relate<TJunction, TEntity, TRelation>(Guid entityGuid, IEnumerable<Guid> listGuid, Func<Guid, Guid, TJunction> callback) where TJunction : BaseTableManyToMany<TEntity, TRelation>
    {
        List<TJunction> list = listGuid.Select(x => callback(entityGuid, x)).ToList();
        List<TJunction> result = await Context.Set<TJunction>().AsNoTracking().Where(x => x.EntityID == entityGuid).ToListAsync();

        List<TJunction> toRemove = result.Where(item => list.All(x => x.RelationID != item.RelationID)).ToList();
        List<TJunction> toAdd = list
            .Where(item => result.All(x => x.RelationID != item.RelationID))
            .Select(item => callback(entityGuid, item.RelationID))
            .ToList();

        await Context.AddRangeAsync(toAdd);
        Context.RemoveRange(toRemove);

        return list;
    }
}
