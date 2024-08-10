using Microsoft.AspNetCore.Mvc;
using WisApi.Models.DTO_s;

namespace WisApi.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<LoginResponseDTO> LoginAsync([FromBody] LoginRequestDTO loginRequestDTO);

        Task<string> RegisterAsync([FromBody] RegisterRequestDTO registerRequestDTO);

        Task<bool> VerifyAccountAsync([FromBody] VerifyEmailRequestDTO verify);

        Task<bool> SignOutAsync(HttpContext context);
    }
}
