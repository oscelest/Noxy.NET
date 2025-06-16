using Noxy.NET.Test.Domain.Entities.Data;
using Noxy.NET.Test.Domain.Entities.Data.Discriminators;
using Noxy.NET.Test.Domain.Entities.Schemas.Discriminators;

namespace Noxy.NET.Test.Application.Interfaces.Repositories;

public interface IDataRepository
{
    Task<List<EntityDataElement>> GetElementListWithIdentifier(string identifier);
    Task<List<EntityDataProperty.Discriminator>> GetPropertyListWithIdentifierAndElementID(string identifier, Guid idElement);
    Task<List<EntityDataSystemParameter>> GetCurrentSystemParameterList();
    Task<List<EntityDataTextParameter>> GetCurrentTextParameterList();
    Task<EntityDataTextParameter> GetCurrentTextParameterByIdentifier(string identifier);

    Task<EntityDataElement> CreateElement(string identifier);
    Task<EntityDataProperty.Discriminator> CreateProperty(Guid element, EntitySchemaProperty property, object? value);
}
