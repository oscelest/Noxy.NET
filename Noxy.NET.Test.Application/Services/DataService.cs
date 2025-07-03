using Noxy.NET.Test.Application.Interfaces;
using Noxy.NET.Test.Application.Interfaces.Services;
using Noxy.NET.Test.Domain.Entities.Data;
using Noxy.NET.Test.Domain.Entities.Data.Discriminators;
using Noxy.NET.Test.Domain.Entities.Schemas;
using Noxy.NET.Test.Domain.Entities.Schemas.Discriminators;
using Noxy.NET.Test.Domain.ViewModels;

namespace Noxy.NET.Test.Application.Services;

public class DataService(IUnitOfWorkFactory serviceUoWFactory, IApplicationService serviceApplication, IViewModelFactoryService serviceViewModelFactory) : IDataService
{
    public ViewModelSchemaContext[] GetContextList()
    {
        return serviceApplication.GetSchemaContext().Select(serviceViewModelFactory.Create).ToArray();
    }

    public ViewModelSchemaContext GetContextListWithIdentifier(string identifier)
    {
        return serviceViewModelFactory.Create(serviceApplication.GetSchemaContext(identifier));
    }

    public ViewModelSchemaAction[] GetActionListWithContextIdentifier(string identifier)
    {
        return serviceApplication.GetSchemaContext(identifier).ActionList?.Select(x => x.Relation != null ? serviceViewModelFactory.Create(x.Relation) : throw new InvalidOperationException()).ToArray() ?? [];
    }

    public async Task<ViewModelDataElement[]> GetElementListWithContextIdentifier(string identifier)
    {
        await using IUnitOfWork uow = await serviceUoWFactory.Create();
        EntitySchemaContext context = serviceApplication.GetSchemaContext(identifier);

        List<ViewModelDataElement> result = [];
        foreach (EntitySchemaElement entitySchemaElement in context.ElementList?.Select(x => x.Relation).OfType<EntitySchemaElement>() ?? [])
        {
            foreach (EntityDataElement entityDataElement in await uow.Data.GetElementListWithIdentifier(entitySchemaElement.SchemaIdentifier))
            {
                List<ViewModelDataProperty> listProperty = [];
                foreach (EntitySchemaProperty entitySchemaProperty in entitySchemaElement.PropertyList?.Select(x => x.Relation?.GetValue()).OfType<EntitySchemaProperty>() ?? [])
                {
                    List<EntityDataProperty.Discriminator> listDataProperty = await uow.Data.GetPropertyListWithIdentifierAndElementID(entitySchemaProperty.SchemaIdentifier, entityDataElement.ID);
                    listProperty.AddRange(listDataProperty.Select(x => x.ToViewModel(entitySchemaProperty)));
                }
                entityDataElement.PropertyList = listProperty.ToArray();

                result.Add(serviceViewModelFactory.Create(entityDataElement));
            }
        }

        return result.ToArray();
    }

    public async Task<List<EntityDataSystemParameter>> GetSystemParameterList()
    {
        await using IUnitOfWork uow = await serviceUoWFactory.Create();
        return await uow.Data.GetCurrentSystemParameterList();
    }

    public async Task<List<EntityDataTextParameter>> GetTextParameterList()
    {
        await using IUnitOfWork uow = await serviceUoWFactory.Create();
        return await uow.Data.GetCurrentTextParameterList();
    }

    public async Task<Dictionary<string, string>> ResolveTextParameterList(IEnumerable<string> list)
    {
        await using IUnitOfWork uow = await serviceUoWFactory.Create();

        Dictionary<string, string> result = [];
        foreach (string identifier in list)
        {
            try
            {
                EntityDataTextParameter entityTextParameter = await uow.Data.GetCurrentTextParameterByIdentifier(identifier);
                result.Add(identifier, entityTextParameter.Value);
            }
            catch
            {
                result.Add(identifier, "[MISSING]");
            }
        }
        
        return result;
    }
}
