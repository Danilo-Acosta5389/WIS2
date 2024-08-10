using MailKit.Security;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using MimeKit;
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

                var checkPasswordResult = await _userManager.CheckPasswordAsync(user, loginRequestDTO.Password);
                if (checkPasswordResult)
                {

                    //Check if user is verified
                    if (user.EmailConfirmed == false)
                    {
                        response.IsVerified = false;
                        return response;
                    }

                    //Check if user is blocked
                    if (user.IsBlocked == true)
                    {
                        response.IsBlocked = true;
                        return response;
                    }

                    // GetHashCode a role for the user
                    var roles = await _userManager.GetRolesAsync(user);
                    if (roles != null)
                    {
                        // Create tokens
                        var jwtToken = _tokenRepository!.CreateJWTToken(user, roles.ToList());
                        var refreshToken = _tokenRepository!.GenerateTokenString(64);

                        response.PublicId = user.PublicId;
                        response.JwtToken = jwtToken;
                        response.RefreshToken = refreshToken;

                        //Setting new refresh token to user
                        user.RefreshToken = response.RefreshToken;
                        user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7);
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

            //Sending verification code to email address
            var verificationCode = await EmailSender(registerRequestDTO.Email);
            user.VerificationCode = verificationCode;

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

        //Veirfy account
        public async Task<bool> VerifyAccountAsync(VerifyEmailRequestDTO verify)
        {
            var user = await _userManager!.FindByEmailAsync(verify.Email);

            if (user!.VerificationCode == verify.Code)
            {
                user.EmailConfirmed = true;
                await _userManager!.UpdateAsync(user);
                return true;
            }

            return false;
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

        private async Task<string> EmailSender(string to)
        {
            string verificationCode = _tokenRepository.GenerateTokenString(8);
            string body = @$"
                <body style="" color:white; max-width:100%;height:max-content; display:flex; flex-direction: column; align-items:center; justify-content:center; font-family: Courier New, Courier, monospace; text-align: center;""> 
                    <div style=""padding:1rem; background-color:black; color:white; border-radius:7px; display:flex; flex-direction: column; align-items:center; justify-content:center;""> 
                        <span style=""margin:5px; color:white; ""> 
                            <h2 style=""margin:0; color:white; "">Hello world </h2> 
                            <br> 
                            <p style=""margin:0; color:white;"">Please enter the verification code below.</p> 
                            <br> 
                            <h2 style=""margin:0; color:white;"">{verificationCode}</h2> 
                        </span> 
                    </div> 
                </body>";

            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(Secrets.Email));
                email.To.Add(MailboxAddress.Parse(to));
                email.Subject = "What Is Space verification code";
                email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = body };

                using var smtp = new SmtpClient();
                smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate(Secrets.Email, Secrets.EmailPass);
                smtp.Send(email);
                smtp.Disconnect(true);
                return verificationCode;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "";
            }
        }
    }
}