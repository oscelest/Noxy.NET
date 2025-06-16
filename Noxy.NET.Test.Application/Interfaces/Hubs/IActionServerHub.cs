using Noxy.NET.Models;
using Noxy.NET.Test.Domain.Models;

namespace Noxy.NET.Test.Application.Interfaces.Hubs;

public interface IActionServerHub
{
    StateAction Register(Guid id, string identifier, Dictionary<string, object?>? context = null);
    void Deregister(Guid id);
    StateAction CommitField(Guid id, string identifier, JsonDiscriminator value);
    object? Submit(Guid id);
}
