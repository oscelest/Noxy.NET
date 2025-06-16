using Noxy.NET.Test.Domain.Entities.Authentication;
using Noxy.NET.Test.Domain.Forms.Authentication;

namespace Noxy.NET.Test.Application.Interfaces.Repositories;

public interface IAuthenticationRepository
{
    public Task<EntityUser> GetUserWithID(Guid id);
    public Task<EntityUser> GetUserWithEmail(string email);
    public Task<EntityUser> GetUserWithEmailAndPassword(string email, string password);
    public Task<EntityUser> CreateUser(string email, string password);
    public void UpdateUser(EntityUser entityUser);

    public Task<List<EntityIdentity>> GetIdentityListWithUserID(Guid idUser);
    public Task<EntityIdentity> GetIdentityWithID(Guid idIdentity);
    public Task<EntityIdentity> CreateIdentity(Guid idUser, SignUpIdentityFormModel model);
}
