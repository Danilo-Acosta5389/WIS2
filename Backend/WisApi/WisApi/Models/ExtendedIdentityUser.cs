﻿using Microsoft.AspNetCore.Identity;


namespace WisApi.Models
{
    public class ExtendedIdentityUser : IdentityUser
    {
        public string PublicId { get; set; }

        public string? RefreshToken { get; set; }
        
        public DateTime RefreshTokenExpiry { get; set; }
    }
}
