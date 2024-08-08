using Microsoft.AspNetCore.Identity;
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
            var response = new LoginResponseDTO();

            if (user != null)
            {
                response.IsSuccess = true;

                if (user.IsBlocked == true)
                {
                    response.IsBlocked = true;
                    return response;
                }

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

                        response.PublicId = user.PublicId;
                        response.JwtToken = jwtToken;
                        response.RefreshToken = refreshToken;

                        //Setting new refresh token to user
                        user.RefreshToken = response.RefreshToken;
                        user.RefreshTokenExpiry = DateTime.UtcNow.AddHours(6);
                        await _userManager.UpdateAsync(user);

                        return response;
                    }
                }
            }

            response.IsSuccess = false;
            return response;
        }

        //Register  USER NOT ALLOWED TO USE "-" and maybe other special chars aswell
        public async Task<string> RegisterAsync(RegisterRequestDTO registerRequestDTO)
        {
            var result = new RegisterResultDTO();

            var user = new ExtendedIdentityUser
            {
                UserName = registerRequestDTO.UserName,
                Email = registerRequestDTO.Email,
                PublicId = Guid.NewGuid().ToString()
            };

            var emailCheck = await _userManager!.FindByEmailAsync(user.Email);
            if (emailCheck != null)
                return "Email already registered";

            //Check username availabillity
            var userNameCheck = await _userManager!.FindByNameAsync(user.UserName);
            if (userNameCheck != null)
                return "Username already taken";

            var identityResult = await _userManager!.CreateAsync(user, registerRequestDTO.Password);

            if (identityResult.Succeeded)
            {
                // add role to this user

                //Default role
                var roles = new string[] { "User" };

                identityResult = await _userManager.AddToRolesAsync(user, roles);
                if (identityResult.Succeeded)
                {
                    return "Success";
                }

                //Save this for later
                //if (registerRequestDTO.Roles != null && registerRequestDTO.Roles.Any())
                //{
                //    identityResult = await _userManager.AddToRolesAsync(user, registerRequestDTO.Roles);
                //    if (identityResult.Succeeded)
                //    {
                //        return true;
                //    }
                //}
            }
            return "Error";
        }

        //Sign out by deleting HttpOnly Cookies
        public async Task<bool> SignOutAsync(HttpContext context)
        {
            context.Request.Cookies.TryGetValue("publicId", out var publicId);
            context.Request.Cookies.TryGetValue("refreshToken", out var refreshToken);

            if (!string.IsNullOrEmpty(refreshToken) && !string.IsNullOrEmpty(publicId))
            {
                var user = _userManager!.Users.Where(x => x.PublicId == publicId && x.RefreshToken == refreshToken).SingleOrDefault();

                if (user == null)
                    return false;


                var cookies = new RefreshCookieDTO(publicId, refreshToken);

                user!.RefreshToken = string.Empty;
                user.RefreshTokenExpiry = DateTime.UtcNow;

                await _userManager.UpdateAsync(user);

                try
                {
                    _tokenRepository.DeleteCookies(context);
                }
                catch (Exception e)
                {

                    Console.WriteLine("ERROR With cookies:" + e.Message);
                }

                return true;
            }

            return false;
        }
    }
}