using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Noxy.NET.Test.Application.Interfaces.Repositories;
using Noxy.NET.Test.Domain.Entities.Data;
using Noxy.NET.Test.Domain.Entities.Data.Discriminators;
using Noxy.NET.Test.Domain.Entities.Schemas;
using Noxy.NET.Test.Domain.Entities.Schemas.Discriminators;
using Noxy.NET.Test.Persistence.Abstractions;
using Noxy.NET.Test.Persistence.Interfaces.Services;
using Noxy.NET.Test.Persistence.Tables.Data;
using Noxy.NET.Test.Persistence.Tables.Data.Discriminators;

namespace Noxy.NET.Test.Persistence.Repositories;

public class DataRepository(DataContext context, IEntityToTableMapper mapperE2T, ITableToEntityMapper mapperT2E) : BaseRepository(context, mapperE2T, mapperT2E), IDataRepository
{
    public async Task<List<EntityDataElement>> GetElementListWithIdentifier(string identifier)
    {
        List<TableDataElement> result = await Context.DataElement.Where(x => x.SchemaIdentifier == identifier).ToListAsync();
        return result.Select(x => MapperT2E.Map(x)).ToList();
    }

    public async Task<List<EntityDataProperty.Discriminator>> GetPropertyListWithIdentifierAndElementID(string identifier, Guid idElement)
    {
        List<TableDataProperty> result = await Context.DataProperty.Where(x => x.SchemaIdentifier == identifier && x.ElementID == idElement).ToListAsync();
        return result.Select(x => new EntityDataProperty.Discriminator(MapperT2E.Map(x))).ToList();
    }

    public async Task<List<EntityDataSystemParameter>> GetCurrentSystemParameterList()
    {
        List<TableDataSystemParameter> result = await Context.DataSystemParameter.ToListAsync();
        return result.Select(MapperT2E.Map).ToList();
    }

    public async Task<List<EntityDataTextParameter>> GetCurrentTextParameterList()
    {
        List<TableDataTextParameter> result = await Context.DataTextParameter.ToListAsync();
        return result.Select(MapperT2E.Map).ToList();
    }

    public async Task<EntityDataTextParameter> GetCurrentTextParameterByIdentifier(string identifier)
    {
        TableDataTextParameter result = await Context.DataTextParameter
            .OrderBy(x => x.TimeCreated)
            .FirstAsync(x => x.SchemaIdentifier == identifier && x.TimeApproved != null && x.TimeEffective < DateTime.Now);

        return MapperT2E.Map(result);
    }

    public async Task<EntityDataElement> CreateElement(string identifier)
    {
        EntityEntry<TableDataElement> result = await Context.DataElement.AddAsync(new()
        {
            SchemaIdentifier = identifier
        });

        return MapperT2E.Map(result.Entity);
    }

    public async Task<EntityDataProperty.Discriminator> CreateProperty(Guid idElement, EntitySchemaProperty property, object? value)
    {
        EntityEntry<TableDataProperty> result = await Context.DataProperty.AddAsync(property switch
        {
            EntitySchemaPropertyBoolean propertyBoolean => CreatePropertyBoolean(idElement, propertyBoolean, value),
            EntitySchemaPropertyDateTime propertyDateTime => CreatePropertyDateTime(idElement, propertyDateTime, value),
            EntitySchemaPropertyString propertyString => CreatePropertyString(idElement, propertyString, value),
            _ => throw new ArgumentOutOfRangeException(nameof(property))
        });

        return new(MapperT2E.Map(result.Entity));
    }

    private static TableDataPropertyBoolean CreatePropertyBoolean(Guid idElement, EntitySchemaPropertyBoolean entity, object? value)
    {
        if (value is not bool parsed) throw new InvalidCastException();

        return new()
        {
            ElementID = idElement,
            SchemaIdentifier = entity.SchemaIdentifier,
            Value = parsed
        };
    }

    private static TableDataPropertyDateTime CreatePropertyDateTime(Guid idElement, EntitySchemaPropertyDateTime entity, object? value)
    {
        if (value is not DateTime parsed) throw new InvalidCastException();

        return new()
        {
            ElementID = idElement,
            SchemaIdentifier = entity.SchemaIdentifier,
            Value = parsed
        };
    }

    private static TableDataPropertyString CreatePropertyString(Guid idElement, EntitySchemaPropertyString entity, object? value)
    {
        if (value is not string parsed) throw new InvalidCastException();

        return new()
        {
            ElementID = idElement,
            SchemaIdentifier = entity.SchemaIdentifier,
            Value = parsed
        };
    }
}
