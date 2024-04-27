using Microsoft.AspNetCore.Mvc;
using WisApi.Models.DTO_s;

namespace WisApi.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<LoginResponseDTO> LoginAsync([FromBody] LoginRequestDTO loginRequestDTO);

        Task<bool> RegisterAsync([FromBody] RegisterRequestDTO registerRequestDTO);

    }
}
