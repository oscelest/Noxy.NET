using Noxy.NET.Test.Domain.Entities.Schemas;

namespace Noxy.NET.Test.Application.Interfaces.Services;

public interface ISchemaBuilderService
{
    Task<EntitySchema> ConstructSchema(Guid? id = null);
}
