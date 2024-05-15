namespace WisApi.Models.DTO_s
{
    public class AccessTokenDTO
    {
        public AccessTokenDTO(string token)
        {
            Token = token;
        }
        public string? Token { get; set; }
    }
}
