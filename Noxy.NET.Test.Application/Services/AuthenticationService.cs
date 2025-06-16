using Noxy.NET.Test.Application.Interfaces;
using Noxy.NET.Test.Application.Interfaces.Services;
using Noxy.NET.Test.Domain.Entities.Authentication;
using Noxy.NET.Test.Domain.Forms.Authentication;

namespace Noxy.NET.Test.Application.Services;

public class AuthenticationService(IUnitOfWorkFactory serviceUoWFactory, IJWTService serviceJWT) : IAuthenticationService
{
    public async Task<string> SignInUser(SignInUserFormModel model)
    {
        await using IUnitOfWork uow = await serviceUoWFactory.Create();
        EntityUser entityUser =  await uow.Authentication.GetUserWithEmailAndPassword(model.Email, model.Password);
        return serviceJWT.Create(entityUser);
    }

    public async Task<string> SignUpUser(SignUpUserFormModel model)
    {
        await using IUnitOfWork uow = await serviceUoWFactory.Create();
        EntityUser entityUser = await uow.Authentication.CreateUser(model.Email, model.Password);
        await uow.Commit();
        return serviceJWT.Create(entityUser);
    }

    public async Task<string> RenewUser(string email)
    {
        await using IUnitOfWork uow = await serviceUoWFactory.Create();

        EntityUser entityUser = await uow.Authentication.GetUserWithEmail(email);
        entityUser.TimeSignIn = DateTime.UtcNow;

        uow.Authentication.UpdateUser(entityUser);
        await uow.Commit();
        
        return serviceJWT.Create(entityUser);
    }

    public async Task<List<EntityIdentity>> GetIdentitySignInList(Guid userId)
    {
        await using IUnitOfWork uow = await serviceUoWFactory.Create();
        return await uow.Authentication.GetIdentityListWithUserID(userId);
    }

    public async Task<EntityIdentity> SignInIdentity(Guid identityId)
    {
        await using IUnitOfWork uow = await serviceUoWFactory.Create();
        return await uow.Authentication.GetIdentityWithID(identityId);
    }

    public async Task<EntityIdentity> SignUpIdentity(Guid userId, SignUpIdentityFormModel form)
    {
        await using IUnitOfWork uow = await serviceUoWFactory.Create();
        EntityIdentity entityIdentity = await uow.Authentication.CreateIdentity(userId, form);
        await uow.Commit();
        return entityIdentity;
    }
}
