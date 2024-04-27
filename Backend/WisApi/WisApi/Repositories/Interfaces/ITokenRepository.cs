using Microsoft.AspNetCore.Identity;

namespace WisApi.Repositories.Interfaces
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
