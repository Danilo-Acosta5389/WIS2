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
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
