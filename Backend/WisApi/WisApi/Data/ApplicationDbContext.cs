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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data for TopicModel
            modelBuilder.Entity<TopicModel>().HasData(
                new TopicModel
                {
                    Id = 1,
                    Title = "General",
                    Description = "Discuss anything and everything under the sun",
                    UserId = "user1",
                    UserName = "UserOne",
                    CreatedAt = DateTime.UtcNow,
                    IpAdress = "192.168.1.1"
                },
                new TopicModel
                {
                    Id = 2,
                    Title = "Technology",
                    Description = "Discuss the latest in tech",
                    UserId = "user2",
                    UserName = "UserTwo",
                    CreatedAt = DateTime.UtcNow,
                    IpAdress = "192.168.1.2"
                }
            );

            // Seed data for PostModel
            modelBuilder.Entity<PostModel>().HasData(
                new PostModel
                {
                    Id = 1,
                    Title = "Welcome to the General Forum",
                    Text = "Feel free to discuss anything here.",
                    CreatedAt = DateTime.UtcNow,
                    UserId = "user1",
                    UserName = "UserOne",
                    IpAdress = "192.168.1.1",
                    TopicId = 1
                },
                new PostModel
                {
                    Id = 2,
                    Title = "Tech News",
                    SubTitle = "Latest updates",
                    Text = "Share and discuss the latest in tech news.",
                    CreatedAt = DateTime.UtcNow,
                    UserId = "user2",
                    UserName = "UserTwo",
                    IpAdress = "192.168.1.2",
                    TopicId = 2
                }
            );

            // Seed data for CommentModel
            modelBuilder.Entity<CommentModel>().HasData(
                new CommentModel
                {
                    Id = 1,
                    UserId = "user3",
                    UserName = "UserThree",
                    CreatedAt = DateTime.UtcNow,
                    IpAdress = "192.168.1.3",
                    PostId = 1
                },
                new CommentModel
                {
                    Id = 2,
                    UserId = "user4",
                    UserName = "UserFour",
                    CreatedAt = DateTime.UtcNow,
                    IpAdress = "192.168.1.4",
                    PostId = 2
                }
            );
        }

    }
}
