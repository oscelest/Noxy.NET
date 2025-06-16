using Noxy.NET.Test.Domain.Entities.Data;

namespace Noxy.NET.Test.Application.Interfaces.Services;

public interface IDynamicValueAPIService
{
    public Task<EntityDataElement> CreateElement(string identifier, Dictionary<string, object?> data);
}
