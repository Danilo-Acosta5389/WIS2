﻿using Microsoft.AspNetCore.Mvc;
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

            if (registerResult != "Error")
                return Ok(new StatusMessageDTO(registerResult));

            else return BadRequest(new StatusMessageDTO("Something went wrong, please try again."));

        }

        // POST: /api/auth/login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            var loginResult = await _authRepository.LoginAsync(loginRequestDTO);

            var response = new ResponseDTO();

            if (loginResult.IsSuccess == true)
            {
                if (loginResult.IsVerified == false)
                {
                    response.Message = "UNVERIFIED";
                    
                    return Ok(response);
                }

                if (loginResult.IsBlocked == true)
                {
                    response.Message = "BLOCKED";
                    
                    return Ok(response);
                }

                var cookieDTO = new RefreshCookieDTO(loginResult.PublicId, loginResult.RefreshToken);

                _tokenRepository.SetTokensInsideCookie(cookieDTO, HttpContext);
                
                response.Token = loginResult.JwtToken!;

                return Ok(response);
            }

            response.Message = "username or password was incorrect";

            return Unauthorized(response);
        }

        [HttpPost("Verify")]
        public async Task<IActionResult> VerifyEmail(VerifyEmailRequestDTO verify)
        {
            var response = await _authRepository.VerifyAccountAsync(verify);
            
            if (response)
                return Ok(new StatusMessageDTO("VERIFIED"));
            
            return BadRequest();
        }

        

        //NEW
        // this might need Authorize annotation
        [HttpPost("RefreshToken")]
        //[Authorize(Roles = "User, Creator, Admin, Super")]
        public async Task<IActionResult> RefreshToken()
        {
            HttpContext.Request.Cookies.TryGetValue("publicId", out var publicId);
            HttpContext.Request.Cookies.TryGetValue("refreshToken", out var refreshToken);
            

            //This will be refactored

            if (!string.IsNullOrEmpty(refreshToken) && !string.IsNullOrEmpty(publicId))
            {

                
                var tokens = new RefreshCookieDTO(publicId, refreshToken);
                var refreshResponse = await _tokenRepository.RefreshToken(tokens);

                var tokenResponse = new RefreshCookieDTO(refreshResponse.PublicId, refreshResponse.RefreshToken);

                _tokenRepository.SetTokensInsideCookie(tokenResponse, HttpContext);

                var response = new AccessTokenDTO(refreshResponse.JwtToken!);

                return Ok(response);
            }
            return Unauthorized();
        }

        [HttpGet("SignOut")]
        public async Task<IActionResult> SignOutUser()
        {
            var response = await _authRepository.SignOutAsync(HttpContext);

            if (response)
                return Ok();
            
            return BadRequest();
        }

    }
}
