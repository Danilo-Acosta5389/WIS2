using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WisApi.Models
{
    public class ExtendedIdentityUser : IdentityUser
    {
        [Required]
        public string PublicId { get; set; }

        public string? RefreshToken { get; set; }
        
        public DateTime RefreshTokenExpiry { get; set; }
    }
}
