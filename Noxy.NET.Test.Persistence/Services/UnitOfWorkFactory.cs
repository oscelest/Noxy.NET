using Microsoft.EntityFrameworkCore;
using Noxy.NET.Test.Application.Interfaces;
using Noxy.NET.Test.Persistence.Interfaces.Services;

namespace Noxy.NET.Test.Persistence.Services;

public sealed class UnitOfWorkFactory(IDbContextFactory<DataContext> factory, IEntityToTableMapper mapperE2T, ITableToEntityMapper mapperT2E) : IUnitOfWorkFactory
{
    public async Task<IUnitOfWork> Create()
    {
        return new UnitOfWork(await factory.CreateDbContextAsync(), mapperE2T, mapperT2E);
    }
}
