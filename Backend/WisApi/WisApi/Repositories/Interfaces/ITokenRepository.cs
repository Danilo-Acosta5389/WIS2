using Microsoft.AspNetCore.Identity;
using WisApi.Models;
using WisApi.Models.DTO_s;

namespace WisApi.Repositories.Interfaces
{
    public interface ITokenRepository
    {
        string CreateJWTToken(ExtendedIdentityUser user, List<string> roles);
        string GenerateTokenString(int byteSize);
        Task<LoginResponseDTO> RefreshToken(RefreshCookieDTO model);
        void SetTokensInsideCookie(RefreshCookieDTO cookie, HttpContext context);
        void DeleteCookies(HttpContext context);
    }
}
