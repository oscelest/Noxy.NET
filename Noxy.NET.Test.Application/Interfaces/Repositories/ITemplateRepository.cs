using Noxy.NET.Test.Domain.Entities.Schemas;

namespace Noxy.NET.Test.Application.Interfaces.Repositories;

public interface ITemplateRepository
{
    Task<List<EntitySchema>> GetSchemaList();
    Task<EntitySchema> Populate(EntitySchema entity);

    Task<EntitySchema> GetSchemaByID(Guid id);
    Task<EntitySchema> GetCurrentSchema();

    Task<EntitySchema> Create(EntitySchema entity);
    
    void Update(EntitySchema entity);
}
