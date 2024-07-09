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
        public DbSet<ReportModel> Reports { get; set; }

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
                    UserName = "User One",
                    CreatedAt = DateTime.UtcNow,
                    IpAdress = "192.168.1.1"
                },
                new TopicModel
                {
                    Id = 2,
                    Title = "Internet Culture",
                    Description = "Explore the latest trends and memes from the web",
                    UserId = "user2",
                    UserName = "User Two",
                    CreatedAt = DateTime.UtcNow,
                    IpAdress = "192.168.1.2"
                },
                new TopicModel
                {
                    Id = 3,
                    Title = "Games",
                    Description = "Share tips, reviews, and news about your favorite games",
                    UserId = "user3",
                    UserName = "User Three",
                    CreatedAt = DateTime.UtcNow,
                    IpAdress = "192.168.1.3"
                },
                new TopicModel
                {
                    Id = 4,
                    Title = "Q&As",
                    Description = "Ask questions and get answers from the community",
                    UserId = "user4",
                    UserName = "User Four",
                    CreatedAt = DateTime.UtcNow,
                    IpAdress = "192.168.1.4"
                },
                new TopicModel
                {
                    Id = 5,
                    Title = "Technology",
                    Description = "Stay updated with the latest tech news and gadgets",
                    UserId = "user5",
                    UserName = "User Five",
                    CreatedAt = DateTime.UtcNow,
                    IpAdress = "192.168.1.5"
                },
                new TopicModel
                {
                    Id = 6,
                    Title = "Pop Culture",
                    Description = "Dive into discussions about music, celebrities, and more",
                    UserId = "user6",
                    UserName = "User Six",
                    CreatedAt = DateTime.UtcNow,
                    IpAdress = "192.168.1.6"
                },
                new TopicModel
                {
                    Id = 7,
                    Title = "Movie & TV",
                    Description = "Discuss the latest movies and TV shows",
                    UserId = "user7",
                    UserName = "User Seven",
                    CreatedAt = DateTime.UtcNow,
                    IpAdress = "192.168.1.7"
                },
                new TopicModel
                {
                    Id = 8,
                    Title = "Politics",
                    Description = "Engage in discussions about current political events",
                    UserId = "user8",
                    UserName = "User Eight",
                    CreatedAt = DateTime.UtcNow,
                    IpAdress = "192.168.1.8"
                },
                new TopicModel
                {
                    Id = 9,
                    Title = "Business",
                    Description = "Share insights and news about the business world",
                    UserId = "user9",
                    UserName = "User Nine",
                    CreatedAt = DateTime.UtcNow,
                    IpAdress = "192.168.1.9"
                },
                new TopicModel
                {
                    Id = 10,
                    Title = "Anime",
                    Description = "Discuss your favorite anime series and movies",
                    UserId = "user10",
                    UserName = "User Ten",
                    CreatedAt = DateTime.UtcNow,
                    IpAdress = "192.168.1.10"
                });

            // Seed data for PostModel
            modelBuilder.Entity<PostModel>().HasData(
                new PostModel
                {
                    Id = 1,
                    Title = "Forum Introduction",
                    Text = "Welcome to the forum! Introduce yourself here. What's your name and what brings you to our forum?",
                    CreatedAt = DateTime.UtcNow,
                    UserId = "user1",
                    UserName = "User One",
                    IpAdress = "192.168.1.1",
                    TopicId = 1
                },
                new PostModel
                {
                    Id = 2,
                    Title = "Daily Thoughts",
                    Text = "What's on your mind today?",
                    CreatedAt = DateTime.UtcNow,
                    UserId = "user1",
                    UserName = "User One",
                    IpAdress = "192.168.1.1",
                    TopicId = 1
                },
                new PostModel
                {
                    Id = 3,
                    Title = "Hobbies and Interests",
                    Text = "Share your favorite hobbies and interests. What hobbies or interests do you enjoy in your free time?",
                    CreatedAt = DateTime.UtcNow,
                    UserId = "user1",
                    UserName = "User One",
                    IpAdress = "192.168.1.1",
                    TopicId = 1
                },
                new PostModel
                {
                    Id = 4,
                    Title = "Time Management",
                    Text = "How do you manage your time effectively? What strategies do you use to manage your time effectively?",
                    CreatedAt = DateTime.UtcNow,
                    UserId = "user1",
                    UserName = "User One",
                    IpAdress = "192.168.1.1",
                    TopicId = 1
                },
                new PostModel
                {
                    Id = 5,
                    Title = "Yearly Goals",
                    Text = "What are your goals for this year? What are your main goals for this year and how do you plan to achieve them?",
                    CreatedAt = DateTime.UtcNow,
                    UserId = "user1",
                    UserName = "User One",
                    IpAdress = "192.168.1.1",
                    TopicId = 1
                },
                new PostModel
                {
                    Id = 6,
                    Title = "Top Memes of 2024",
                    Text = "The funniest memes of 2024. Which meme has made you laugh the most this year?",
                    CreatedAt = DateTime.UtcNow,
                    UserId = "user2",
                    UserName = "User Two",
                    IpAdress = "192.168.1.2",
                    TopicId = 2
                },
                new PostModel
                {
                    Id = 7,
                    Title = "Trending Hashtags",
                    Text = "Trending hashtags and their origins. What's your favorite trending hashtag and its story?",
                    CreatedAt = DateTime.UtcNow,
                    UserId = "user2",
                    UserName = "User Two",
                    IpAdress = "192.168.1.2",
                    TopicId = 2
                },
                new PostModel
                {
                    Id = 8,
                    Title = "Internet Challenges",
                    Text = "Internet challenges: Are they safe? Have you tried any internet challenges? Were they safe?",
                    CreatedAt = DateTime.UtcNow,
                    UserId = "user2",
                    UserName = "User Two",
                    IpAdress = "192.168.1.2",
                    TopicId = 2
                },
                new PostModel
                {
                    Id = 9,
                    Title = "Viral Videos",
                    Text = "Viral videos: What makes them so popular? What elements do you think contribute to a video going viral?",
                    CreatedAt = DateTime.UtcNow,
                    UserId = "user2",
                    UserName = "User Two",
                    IpAdress = "192.168.1.2",
                    TopicId = 2
                },
                new PostModel
                {
                    Id = 10,
                    Title = "Online Communities",
                    Text = "Online communities you should join. What online communities do you recommend joining and why?",
                    CreatedAt = DateTime.UtcNow,
                    UserId = "user2",
                    UserName = "User Two",
                    IpAdress = "192.168.1.2",
                    TopicId = 2
                });
        }
    }
}
