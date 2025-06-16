using Noxy.NET.Test.Domain.Entities.Authentication;
using Noxy.NET.Test.Domain.Forms.Authentication;

namespace Noxy.NET.Test.Application.Interfaces.Services;

public interface IAuthenticationService
{
    Task<string> SignInUser(SignInUserFormModel model);
    Task<string> SignUpUser(SignUpUserFormModel model);
    Task<string> RenewUser(string email);

    public Task<List<EntityIdentity>> GetIdentitySignInList(Guid userId);
    public Task<EntityIdentity> SignInIdentity(Guid identityId);
    public Task<EntityIdentity> SignUpIdentity(Guid userId, SignUpIdentityFormModel form);
}