using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WisApi.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }
    }
}
