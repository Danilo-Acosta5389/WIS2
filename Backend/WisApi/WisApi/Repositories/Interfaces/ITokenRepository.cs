using Microsoft.AspNetCore.Identity;
using WisApi.Models;
using WisApi.Models.DTO_s;

namespace WisApi.Repositories.Interfaces
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
        string GenerateRefreshTokenString();
        Task<LoginResponseDTO> RefreshToken(RefreshCookieDTO model);
        void SetTokensInsideCookie(RefreshCookieDTO cookie, HttpContext context);
    }
}
