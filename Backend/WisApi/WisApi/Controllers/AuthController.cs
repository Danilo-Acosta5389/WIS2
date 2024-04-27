using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WisApi.Models;
using WisApi.Models.DTO_s;
using WisApi.Repositories.Interfaces;

namespace WisApi.Controllers
{

    //THIS MUST BE REFACTORED INTO IREPO AND SERVICES
    //THIS IS ONLY FOR DEVELOPMENT AND TESTING

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ExtendedIdentityUser>? _userManager;
        private readonly ITokenRepository _tokenRepository;
        public AuthController(UserManager<ExtendedIdentityUser> userManager, ITokenRepository tokenRepository)
        {
            _userManager = userManager;
            _tokenRepository = tokenRepository;
        }

        // POST: /api/auth/register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDTO)
        {
            var identityUser = new ExtendedIdentityUser
            {
                UserName = registerRequestDTO.UserName,
                Email = registerRequestDTO.Email
            };
            var identityResult = await _userManager!.CreateAsync(identityUser, registerRequestDTO.Password);

            if (identityResult.Succeeded)
            {
                // add role to this user
                if (registerRequestDTO.Roles != null && registerRequestDTO.Roles.Any())
                {
                    identityResult = await _userManager.AddToRolesAsync(identityUser, registerRequestDTO.Roles);
                    if (identityResult.Succeeded)
                    {
                        return Ok("The user was successfully registered! You can now login.");
                    }
                }
            }
            return BadRequest("Sorry, it did not work this tine.");
        }

        // POST: /api/auth/login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
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
                            IsLoggedIn = true,
                            JwtToken = jwtToken,
                            RefreshToken = refreshToken
                        };

                        //Setting new refresh token to user
                        user.RefreshToken = response.RefreshToken;
                        user.RefreshTokenExpiry = DateTime.UtcNow.AddHours(6);
                        await _userManager.UpdateAsync(user);

                        return Ok(response);
                    }
                }
            }
            return BadRequest("username or password was incorrect");
        }


        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken(RefreshTokenModel model)
        {
            var loginResult = await _tokenRepository.RefreshToken(model);
            if (loginResult.IsLoggedIn == true)
            {
                return Ok(loginResult);
            }
            return Unauthorized();
        }
    }
}
