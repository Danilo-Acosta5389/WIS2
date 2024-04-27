namespace WisApi.Models.DTO_s
{
    public class LoginResponseDTO
    {
        public bool IsLoggedIn { get; set; } = false;
        public string? JwtToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}
