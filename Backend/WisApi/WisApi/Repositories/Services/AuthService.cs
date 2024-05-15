using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WisApi.Models;
using WisApi.Models.DTO_s;
using WisApi.Repositories.Interfaces;

namespace WisApi.Repositories.Services
{
    public class AuthService : IAuthRepository
    {
        private readonly UserManager<ExtendedIdentityUser>? _userManager;
        private readonly ITokenRepository _tokenRepository;
        public AuthService(UserManager<ExtendedIdentityUser> userManager, ITokenRepository tokenRepository)
        {
            _userManager = userManager;
            _tokenRepository = tokenRepository;
        }


        //Login
        public async Task<LoginResponseDTO> LoginAsync(LoginRequestDTO loginRequestDTO)
        {
            var user = await _userManager!.FindByEmailAsync(loginRequestDTO.Username);

            if (user != null)
            {
                var checkPasswordResult = await _userManager.CheckPasswordAsync(user, loginRequestDTO.Password);
                if (checkPasswordResult)
                {
                    // GetHashCode a role for the user
                    var roles = await _userManager.GetRolesAsync(user);
                    if (roles != null)
                    {
                        // Create tokens
                        var jwtToken = _tokenRepository!.CreateJWTToken(user, roles.ToList());
                        var refreshToken = _tokenRepository!.GenerateRefreshTokenString();
                        var response = new LoginResponseDTO
                        {
                            PublicId = user.PublicId,
                            JwtToken = jwtToken,
                            RefreshToken = refreshToken
                        };



                        //Setting new refresh token to user
                        user.RefreshToken = response.RefreshToken;
                        user.RefreshTokenExpiry = DateTime.UtcNow.AddHours(6);
                        await _userManager.UpdateAsync(user);

                        return response;
                    }
                }
            }
            return new LoginResponseDTO();
        }

        //Register  USER NOT ALLOWED TO USE "-" and maybe other special chars aswell
        public async Task<bool> RegisterAsync(RegisterRequestDTO registerRequestDTO)
        {
            var user = new ExtendedIdentityUser
            {
                UserName = registerRequestDTO.UserName,
                Email = registerRequestDTO.Email,
                PublicId = Guid.NewGuid().ToString()
        };
            var identityResult = await _userManager!.CreateAsync(user, registerRequestDTO.Password);

            if (identityResult.Succeeded)
            {
                // add role to this user
                if (registerRequestDTO.Roles != null && registerRequestDTO.Roles.Any())
                {
                    identityResult = await _userManager.AddToRolesAsync(user, registerRequestDTO.Roles);
                    if (identityResult.Succeeded)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}