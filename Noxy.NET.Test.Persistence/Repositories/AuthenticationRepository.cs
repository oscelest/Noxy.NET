using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Noxy.NET.Test.Application.Interfaces.Repositories;
using Noxy.NET.Test.Domain.Entities.Authentication;
using Noxy.NET.Test.Domain.Forms.Authentication;
using Noxy.NET.Test.Persistence.Abstractions;
using Noxy.NET.Test.Persistence.Interfaces.Services;
using Noxy.NET.Test.Persistence.Tables.Authentication;

namespace Noxy.NET.Test.Persistence.Repositories;

public class AuthenticationRepository(DataContext context, IEntityToTableMapper mapperE2T, ITableToEntityMapper mapperT2E) : BaseRepository(context, mapperE2T, mapperT2E), IAuthenticationRepository
{
    private static int KeySize => 64;
    private static int HashIterations => 64;
    private static HashAlgorithmName HashAlgorithm => HashAlgorithmName.SHA512;

    public async Task<EntityUser> GetUserWithID(Guid id)
    {
        TableUser tableUser = await Context.User.AsNoTracking().FirstAsync(x => x.ID == id);
        return MapperT2E.Map(tableUser);
    }

    public async Task<EntityUser> GetUserWithEmail(string email)
    {
        TableUser tableUser = await Context.User.AsNoTracking().FirstAsync(x => x.Email == email);
        return MapperT2E.Map(tableUser);
    }
    
    public async Task<EntityUser> GetUserWithEmailAndPassword(string email, string password)
    {
        TableUser tableUser = await Context.User.AsNoTracking().Include(x => x.Authentication).FirstAsync(x => x.Email == email);
        if (tableUser.Authentication == null)
        {
            throw new();
        }

        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(password), tableUser.Authentication.Salt, HashIterations, HashAlgorithm, KeySize);
        if (!CryptographicOperations.FixedTimeEquals(tableUser.Authentication.Hash, hash))
        {
            throw new();
        }

        return MapperT2E.Map(tableUser);
    }

    public async Task<EntityUser> CreateUser(string email, string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(KeySize);
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(password), salt, HashIterations, HashAlgorithm, KeySize);

        EntityEntry<TableAuthentication> entryAuthentication = await Context.Authentication.AddAsync(new()
        {
            Salt = salt,
            Hash = hash,
        });
        
        EntityEntry<TableUser> entryUser = await Context.User.AddAsync(new()
        {
            Email = email, 
            AuthenticationID = entryAuthentication.Entity.ID,
        });

        return MapperT2E.Map(entryUser.Entity);
    }

    public void UpdateUser(EntityUser entityUser)
    {
        Context.User.Update(MapperE2T.Map(entityUser));
    }

    public async Task<List<EntityIdentity>> GetIdentityListWithUserID(Guid idUser)
    {
        List<TableIdentity> list = await Context.Identity
            .AsNoTracking()
            .AsSplitQuery()
            .Where(x => x.UserID == idUser)
            .ToListAsync();

        return list.Select(MapperT2E.Map).ToList();
    }

    public async Task<EntityIdentity> GetIdentityWithID(Guid idIdentity)
    {
        TableIdentity tableIdentity = await Context.Identity
            .AsNoTracking()
            .AsSplitQuery()
            .SingleAsync(x => x.ID == idIdentity);

        return MapperT2E.Map(tableIdentity);
    }

    public async Task<EntityIdentity> CreateIdentity(Guid idUser, SignUpIdentityFormModel model)
    {
        int order = await Context.Identity.Where(x => x.UserID == idUser).MaxAsync(x => (int?)x.Order) ?? -1;

        EntityEntry<TableIdentity> entryIdentity = await Context.Identity.AddAsync(new()
        {
            Username = model.Username,
            UserID = idUser,
            Handle = model.Username,
            Order = order
        });

        return MapperT2E.Map(entryIdentity.Entity);
    }
}
