﻿namespace WisApi.Models.DTO_s
{
    public class LoginResponseDTO
    {
        public string? PublicId { get; set; } = "";
        public string? JwtToken { get; set; } = "";
        public string? RefreshToken { get; set; } = "";
        public bool? IsBlocked { get; set; }
        public bool? IsSuccess { get; set; }
        public bool? IsVerified { get; set; }
    }
}
