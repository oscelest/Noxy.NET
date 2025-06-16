using Microsoft.Extensions.DependencyInjection;
using Noxy.NET.Test.Application.Interfaces;
using Noxy.NET.Test.Application.Interfaces.Services;
using Noxy.NET.Test.Domain.Entities.Data;
using Noxy.NET.Test.Domain.Entities.Data.Discriminators;
using Noxy.NET.Test.Domain.Entities.Schemas.Discriminators;

namespace Noxy.NET.Test.Application.Services;

public class DynamicValueAPIService(IServiceProvider serviceProvider, IApplicationService serviceApplication) : IDynamicValueAPIService
{
    public async Task<EntityDataElement> CreateElement(string identifier, Dictionary<string, object?>? data = null)
    {
        await using IUnitOfWork uow = await GetUnitOfWork();

        EntityDataElement entityElement = await uow.Data.CreateElement(identifier);
        entityElement.PropertyList = [];

        foreach (KeyValuePair<string, object?> item in data ?? [])
        {
            EntitySchemaProperty.Discriminator schemaProperty = serviceApplication.GetSchemaProperty(item.Key);
            EntityDataProperty.Discriminator entityProperty = await uow.Data.CreateProperty(entityElement.ID, schemaProperty.GetValue(), item.Value);
            entityElement.PropertyList.Add(entityProperty);
        }

        await uow.Commit(true);

        return entityElement;
    }

    private async Task<IUnitOfWork> GetUnitOfWork()
    {
        using IServiceScope scope = serviceProvider.CreateScope();

        IUnitOfWorkFactory factory = scope.ServiceProvider.GetRequiredService<IUnitOfWorkFactory>();
        IUnitOfWork context = await factory.Create();

        return context;
    }
}
