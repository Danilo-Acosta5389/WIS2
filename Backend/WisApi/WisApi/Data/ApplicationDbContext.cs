using Microsoft.EntityFrameworkCore;
using WisApi.Models;

namespace WisApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) { }

        public DbSet<TopicModel> Topics { get; set; }
        public DbSet<PostModel> Posts { get; set; }
        public DbSet<CommentModel> Comments { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<TopicModel>()
        //        .HasMany(e => e.Posts)
        //        .WithOne(e => e.Topic)
        //        .HasForeignKey(e => e.TopicId)
        //        .IsRequired();

        //    modelBuilder.Entity<PostModel>()
        //        .HasMany(e => e.Comments)
        //        .WithOne(e => e.Post)
        //        .HasForeignKey(e => e.PostId)
        //        .IsRequired();
        //}

    }
}
