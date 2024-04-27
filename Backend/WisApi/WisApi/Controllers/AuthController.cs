using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WisApi.Models;
using WisApi.Models.DTO_s;
using WisApi.Repositories.Interfaces;

namespace WisApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenRepository _tokenRepository;
        private readonly IAuthRepository _authRepository;

        public AuthController(ITokenRepository tokenRepository, IAuthRepository authRepository)
        {
            _tokenRepository = tokenRepository;
            _authRepository = authRepository;

        }

        // POST: /api/auth/register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDTO)
        {
            var registerResult = await _authRepository.RegisterAsync(registerRequestDTO);
            
            if (registerResult == true)
                return Ok("The user was successfully registered! You can now login.");
            
            else return BadRequest("Something went wrong, please try again.");

        }

        // POST: /api/auth/login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            var loginResult = await _authRepository.LoginAsync(loginRequestDTO);
            
            if (loginResult.IsLoggedIn == true)
                return Ok(loginResult);

            else return BadRequest("username or password was incorrect");
        }

        // this might need Authorize annotation
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
