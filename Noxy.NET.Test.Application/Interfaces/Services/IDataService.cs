using Noxy.NET.Test.Domain.Entities.Data;
using Noxy.NET.Test.Domain.ViewModels;

namespace Noxy.NET.Test.Application.Interfaces.Services;

public interface IDataService
{
    ViewModelSchemaContext[] GetContextList();
    ViewModelSchemaContext GetContextListWithIdentifier(string identifier);

    ViewModelSchemaAction[] GetActionListWithContextIdentifier(string identifier);

    Task<ViewModelDataElement[]> GetElementListWithContextIdentifier(string identifier);

    Task<List<EntityDataSystemParameter>> GetSystemParameterList();
    Task<List<EntityDataTextParameter>> GetTextParameterList();
    
    Task<Dictionary<string, string>> ResolveTextParameterList(IEnumerable<string> list);
}
