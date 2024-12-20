using Microsoft.AspNetCore.Identity;

namespace NZWalk.API.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
