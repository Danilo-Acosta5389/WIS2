namespace WisApi.Models.DTO_s
{
    public class RefreshCookieDTO
    {
        #nullable disable

        public RefreshCookieDTO() { }

        public RefreshCookieDTO(string publicId, string refreshToken)
        {
            PublicId = publicId;

            RefreshToken = refreshToken;

        }

        public string PublicId { get; set; }

        public string RefreshToken { get; set; }
    }
}
