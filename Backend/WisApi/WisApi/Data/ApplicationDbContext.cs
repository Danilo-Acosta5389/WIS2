using Microsoft.EntityFrameworkCore;

namespace WisApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) { }

    }
}
