namespace WisApi.Models.DTO_s
{
    #nullable disable
    public class RefreshTokenDTO
    {
        public RefreshTokenDTO() { }

        public RefreshTokenDTO(string jwtToken, string refreshToken)
        {
            JwtToken = jwtToken;
            RefreshToken = refreshToken;
        }
        public string JwtToken { get; set; }

        public string RefreshToken { get; set; }
    }
}
