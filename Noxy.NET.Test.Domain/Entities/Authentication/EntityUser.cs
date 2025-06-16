using Noxy.NET.Test.Domain.Abstractions.Entities;

namespace Noxy.NET.Test.Domain.Entities.Authentication;

public class EntityUser : BaseEntity
{
    public required string Email { get; set; }

    public required DateTime TimeSignIn { get; set; }
    public required DateTime? TimeVerified { get; set; }

    public required Guid AuthenticationID { get; set; }
    public required EntityAuthentication? Authentication { get; set; }
    
    public required List<EntityIdentity>? IdentityList { get; set; }
}
