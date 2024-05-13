namespace WisApi.Models.DTO_s
{
    public class LoginResponseDTO
    {
        public string? JwtToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}
