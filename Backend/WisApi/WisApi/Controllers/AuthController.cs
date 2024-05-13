using Microsoft.AspNetCore.Mvc;
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

            if (loginResult != null)
            {
                var tokenDTO = new TokenDTO(loginResult.JwtToken, loginResult.RefreshToken);

                _tokenRepository.SetTokensInsideCookie(tokenDTO, HttpContext);

                return Ok();
            }

            else return BadRequest("username or password was incorrect");
        }

        //OLD
        // this might need Authorize annotation
        //[HttpPost("RefreshToken")]
        //public async Task<IActionResult> RefreshToken(RefreshTokenDTO model)
        //{
        //    var loginResult = await _tokenRepository.RefreshToken(model);
        //    if (loginResult != null)
        //    {
        //        return Ok(loginResult);
        //    }
        //    return Unauthorized();
        //}

        //NEW
        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken()
        {
            HttpContext.Request.Cookies.TryGetValue("accessToken", out var accessToken);
            HttpContext.Request.Cookies.TryGetValue("refreshToken", out var refreshToken);

            //This will be refactored

            if (!string.IsNullOrEmpty(refreshToken))
            {
                var refreshDTO = new RefreshTokenDTO(accessToken, refreshToken);

                var refreshResponse = await _tokenRepository.RefreshToken(refreshDTO);

                var tokenResponse = new TokenDTO(refreshResponse.JwtToken, refreshResponse.RefreshToken);

                _tokenRepository.SetTokensInsideCookie(tokenResponse, HttpContext);

                return Ok();
            }
            return Unauthorized();
        }
    }
}
