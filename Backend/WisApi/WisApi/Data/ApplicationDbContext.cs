using Microsoft.EntityFrameworkCore;

namespace WisApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) { }
    }
}
