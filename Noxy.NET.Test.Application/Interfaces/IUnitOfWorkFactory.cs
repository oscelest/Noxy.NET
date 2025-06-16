namespace Noxy.NET.Test.Application.Interfaces;

public interface IUnitOfWorkFactory
{
    Task<IUnitOfWork> Create();
}
