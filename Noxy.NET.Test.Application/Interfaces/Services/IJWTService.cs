using System.IdentityModel.Tokens.Jwt;
using Noxy.NET.Test.Domain.Entities.Authentication;

namespace Noxy.NET.Test.Application.Interfaces.Services;

public interface IJWTService
{
    string Create(EntityUser entityUser);
    JwtSecurityToken ReadJWT(string jwt);
}
