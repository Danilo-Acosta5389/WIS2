using Microsoft.AspNetCore.Identity;


namespace WisApi.Models
{
    public class ExtendedIdentityUser : IdentityUser
    {
        public string PublicId { get; set; }

        public string? RefreshToken { get; set; }
        
        public DateTime RefreshTokenExpiry { get; set; }

        public bool IsBlocked { get; set; } = false;

        public string? Bio {  get; set; }

        public string? ImageName {  get; set; }
    }
}
