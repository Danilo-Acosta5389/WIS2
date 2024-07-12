using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WisApi.Models;

namespace WisApi.Data
{
    public class AuthDbContext : IdentityDbContext<ExtendedIdentityUser>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var userRoleId = "379a97a4-b993-47be-88fb-0d5aeb855cd5";
            var creatorRoleId = "1f5818c6-fee3-4158-982f-a2fe787be191";
            var adminRoleId = "3feb82b5-09d7-4131-b22f-4bba832dee35";
            var superRoleId = "a54ace02-d2ea-4fea-9bc3-60c95f18fb0b";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = userRoleId,
                    Name = "User",
                    NormalizedName = "USER"
                },
                new IdentityRole
                {
                    Id = creatorRoleId,
                    Name = "Creator",
                    NormalizedName = "CREATOR"
                },
                new IdentityRole
                {
                    Id= adminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = superRoleId,
                    Name = "Super",
                    NormalizedName = "SUPER"
                }

            };

            var alan = new ExtendedIdentityUser
            {
                Id = "6d8a0a9d-2f71-48c5-a2f0-38ec39c4e703",
                UserName = "turing-c0mplete",
                Email = "alan@example.com",
                NormalizedEmail = "alan@example.com".ToUpper(),
                EmailConfirmed = false,
                PasswordHash = "AQAAAAIAAYagAAAAEIetXl7p1Ttix+2XzMxdrW8+tjzcUBUcgvb30e+YJInUDavI4XvLRSe21bT6aT1HFA==",
                SecurityStamp = "GRDTK2VAAUGEO3H2ZVBOR4FRUU3EIWUE",
                ConcurrencyStamp = "e8dc401f-24d8-45b5-85af-1091a93fa5dc",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0,
                RefreshToken = "",
                RefreshTokenExpiry = DateTime.UtcNow,
                PublicId = "b3f7ad63-e494-4cf4-82b1-118d8ebd4545",
                IsBlocked = false,
                Bio = "Pioneering mathematician and logician, I developed the Turing machine concept and broke the Enigma code in WWII. My work laid the foundations for computer science and artificial intelligence. Passionate about mathematics and cryptography.",
                ImageName = "",

            };

            var alanSuperRole = new IdentityUserRole<string>
            {
                UserId = alan.Id,
                RoleId = superRoleId,
            };

            // Add the UserRole entity to the model builder
            builder.Entity<ExtendedIdentityUser>().HasData(alan);
            builder.Entity<IdentityRole>().HasData(roles);
            builder.Entity<IdentityUserRole<string>>().HasData(alanSuperRole);
        }
    }
}
