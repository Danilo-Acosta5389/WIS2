using Azure.Core;

namespace WisApi.Models.DTO_s
{
    public class TokenDTO
    {
        public TokenDTO(string accessToken, string refreshToken)
        {
            AccessToken = accessToken;
            
            RefreshToken = refreshToken;
        }

        //AccessToken == JwtToken in other classes
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }
    }
}
