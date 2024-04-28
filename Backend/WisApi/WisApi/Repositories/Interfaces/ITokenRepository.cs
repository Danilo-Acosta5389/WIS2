using Microsoft.AspNetCore.Identity;
using WisApi.Models;
using WisApi.Models.DTO_s;

namespace WisApi.Repositories.Interfaces
{
    public interface ITokenRepository
    {
        public string CreateJWTToken(IdentityUser user, List<string> roles);
        public string GenerateRefreshTokenString();
        public Task<LoginResponseDTO> RefreshToken(RefreshTokenDTO model);
    }
}
