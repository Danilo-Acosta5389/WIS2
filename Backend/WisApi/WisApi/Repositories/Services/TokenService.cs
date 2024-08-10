using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WisApi.Models;
using WisApi.Models.DTO_s;
using WisApi.Repositories.Interfaces;

namespace WisApi.Repositories.Services
{
    public class TokenService : ITokenRepository
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ExtendedIdentityUser> _userManager;
        public TokenService(IConfiguration configuration, UserManager<ExtendedIdentityUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        public string CreateJWTToken(ExtendedIdentityUser user, List<string> roles)
        {
            // Create claims
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.UserName!));   //Might want to check what is relevant in claims for this app in particualar
            claims.Add(new Claim("image", string.Format("{0}/Images/{1}", "https://localhost:7118", user.ImageName))); // this is totally temporary
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddSeconds(5),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        // SetTokensInsideCookie Should be dependent on RefreshToken method
        public async Task<LoginResponseDTO> RefreshToken(RefreshCookieDTO model)
        {
            //var principal = GetTokenPrincipal(model.JwtToken);

            var user = _userManager.Users.Where(x => x.PublicId == model.PublicId).SingleOrDefault();

            var response = new LoginResponseDTO();

            //var identityUser = await _userManager.FindByEmailAsync(principal.Identity.Name); 

            if (user is null || user.RefreshToken != model.RefreshToken || user.RefreshTokenExpiry < DateTime.UtcNow || user.IsBlocked == true)
            {
                return response;
            }

            var roles = await _userManager.GetRolesAsync(user);

            // Create tokens
            var jwtToken = CreateJWTToken(user, roles.ToList());
            var refreshToken = GenerateTokenString(64);

            response = new LoginResponseDTO
            {
                PublicId = user.PublicId,
                JwtToken = jwtToken,
                RefreshToken = refreshToken
            };

            //Setting new refresh token to user
            user.RefreshToken = response.RefreshToken;
            user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(6);
            await _userManager.UpdateAsync(user);
            return response;
        }

        private ClaimsPrincipal? GetTokenPrincipal(string token)
        {
            var securityKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

            var validation = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _configuration["Jwt:Issuer"],
                ValidAudience = _configuration["Jwt:Audience"],
                IssuerSigningKey = securityKey
            };
            return new JwtSecurityTokenHandler().ValidateToken(token, validation, out _);
        }


        public string GenerateTokenString(int byteSize)
        {
            var randomNumber = new byte[byteSize];

            using (var numberGenerator = RandomNumberGenerator.Create())
            {
                numberGenerator.GetBytes(randomNumber);
            }

            return Convert.ToBase64String(randomNumber);
        }


        // SetTokensInsideCookie Should be dependent on RefreshToken method
        public void SetTokensInsideCookie(RefreshCookieDTO cookie, HttpContext context )
        {

            context.Response.Cookies.Append("publicId", cookie.PublicId,
                new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddDays(5),
                    HttpOnly = true,
                    IsEssential = true,
                    Secure = true,
                    SameSite = SameSiteMode.None,
                });

            context.Response.Cookies.Append("refreshToken", cookie.RefreshToken,
                new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddDays(5),
                    HttpOnly = true,
                    IsEssential = true,
                    Secure = true,
                    SameSite = SameSiteMode.None,
                });
        }


        // Will delete cookies from browser
        public void DeleteCookies(HttpContext context)
        {
            context.Response.Cookies.Delete("publicId", 
                new CookieOptions
                {
                    HttpOnly = true,
                    IsEssential = true,
                    Secure = true,
                    SameSite = SameSiteMode.None
                });
            context.Response.Cookies.Delete("refreshToken", 
                new CookieOptions
                {
                    HttpOnly = true,
                    IsEssential = true,
                    Secure = true,
                    SameSite = SameSiteMode.None
                });

        }
    }
}
