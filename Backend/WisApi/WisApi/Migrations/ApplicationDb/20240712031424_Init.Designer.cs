﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WisApi.Data;

#nullable disable

namespace WisApi.Migrations.ApplicationDb
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240712031424_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("WisApi.Models.CommentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("IpAdress")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsAnonymous")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsInvisible")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("WisApi.Models.PostModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("IpAdress")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsAnonymous")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsInvisible")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SubTitle")
                        .HasColumnType("longtext");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TopicId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("TopicId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 7, 12, 3, 14, 23, 914, DateTimeKind.Utc).AddTicks(5198),
                            IpAdress = "192.168.1.1",
                            IsAnonymous = false,
                            IsInvisible = false,
                            Text = "Welcome to the forum! Introduce yourself here. What's your name and what brings you to our forum?",
                            Title = "Forum Introduction",
                            TopicId = 1,
                            UserId = "user1",
                            UserName = "User One"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 7, 12, 3, 14, 23, 914, DateTimeKind.Utc).AddTicks(5200),
                            IpAdress = "192.168.1.1",
                            IsAnonymous = false,
                            IsInvisible = false,
                            Text = "What's on your mind today?",
                            Title = "Daily Thoughts",
                            TopicId = 1,
                            UserId = "user1",
                            UserName = "User One"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 7, 12, 3, 14, 23, 914, DateTimeKind.Utc).AddTicks(5202),
                            IpAdress = "192.168.1.1",
                            IsAnonymous = false,
                            IsInvisible = false,
                            Text = "Share your favorite hobbies and interests. What hobbies or interests do you enjoy in your free time?",
                            Title = "Hobbies and Interests",
                            TopicId = 1,
                            UserId = "user1",
                            UserName = "User One"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2024, 7, 12, 3, 14, 23, 914, DateTimeKind.Utc).AddTicks(5203),
                            IpAdress = "192.168.1.1",
                            IsAnonymous = false,
                            IsInvisible = false,
                            Text = "How do you manage your time effectively? What strategies do you use to manage your time effectively?",
                            Title = "Time Management",
                            TopicId = 1,
                            UserId = "user1",
                            UserName = "User One"
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2024, 7, 12, 3, 14, 23, 914, DateTimeKind.Utc).AddTicks(5205),
                            IpAdress = "192.168.1.1",
                            IsAnonymous = false,
                            IsInvisible = false,
                            Text = "What are your goals for this year? What are your main goals for this year and how do you plan to achieve them?",
                            Title = "Yearly Goals",
                            TopicId = 1,
                            UserId = "user1",
                            UserName = "User One"
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2024, 7, 12, 3, 14, 23, 914, DateTimeKind.Utc).AddTicks(5206),
                            IpAdress = "192.168.1.2",
                            IsAnonymous = false,
                            IsInvisible = false,
                            Text = "The funniest memes of 2024. Which meme has made you laugh the most this year?",
                            Title = "Top Memes of 2024",
                            TopicId = 2,
                            UserId = "user2",
                            UserName = "User Two"
                        },
                        new
                        {
                            Id = 7,
                            CreatedAt = new DateTime(2024, 7, 12, 3, 14, 23, 914, DateTimeKind.Utc).AddTicks(5207),
                            IpAdress = "192.168.1.2",
                            IsAnonymous = false,
                            IsInvisible = false,
                            Text = "Trending hashtags and their origins. What's your favorite trending hashtag and its story?",
                            Title = "Trending Hashtags",
                            TopicId = 2,
                            UserId = "user2",
                            UserName = "User Two"
                        },
                        new
                        {
                            Id = 8,
                            CreatedAt = new DateTime(2024, 7, 12, 3, 14, 23, 914, DateTimeKind.Utc).AddTicks(5209),
                            IpAdress = "192.168.1.2",
                            IsAnonymous = false,
                            IsInvisible = false,
                            Text = "Internet challenges: Are they safe? Have you tried any internet challenges? Were they safe?",
                            Title = "Internet Challenges",
                            TopicId = 2,
                            UserId = "user2",
                            UserName = "User Two"
                        },
                        new
                        {
                            Id = 9,
                            CreatedAt = new DateTime(2024, 7, 12, 3, 14, 23, 914, DateTimeKind.Utc).AddTicks(5210),
                            IpAdress = "192.168.1.2",
                            IsAnonymous = false,
                            IsInvisible = false,
                            Text = "Viral videos: What makes them so popular? What elements do you think contribute to a video going viral?",
                            Title = "Viral Videos",
                            TopicId = 2,
                            UserId = "user2",
                            UserName = "User Two"
                        },
                        new
                        {
                            Id = 10,
                            CreatedAt = new DateTime(2024, 7, 12, 3, 14, 23, 914, DateTimeKind.Utc).AddTicks(5211),
                            IpAdress = "192.168.1.2",
                            IsAnonymous = false,
                            IsInvisible = false,
                            Text = "Online communities you should join. What online communities do you recommend joining and why?",
                            Title = "Online Communities",
                            TopicId = 2,
                            UserId = "user2",
                            UserName = "User Two"
                        });
                });

            modelBuilder.Entity("WisApi.Models.ReportModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("HandledBy")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("HandledTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Ip")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool?>("IsHandled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Message")
                        .HasColumnType("longtext");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("WisApi.Models.TopicModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("IpAdress")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsAnonymous")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsInvisible")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Topics");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 7, 12, 3, 14, 23, 914, DateTimeKind.Utc).AddTicks(5064),
                            Description = "Discuss anything and everything under the sun",
                            IpAdress = "192.168.1.1",
                            IsAnonymous = false,
                            IsInvisible = false,
                            Title = "General",
                            UserId = "user1",
                            UserName = "User One"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 7, 12, 3, 14, 23, 914, DateTimeKind.Utc).AddTicks(5070),
                            Description = "Explore the latest trends and memes from the web",
                            IpAdress = "192.168.1.2",
                            IsAnonymous = false,
                            IsInvisible = false,
                            Title = "Internet Culture",
                            UserId = "user2",
                            UserName = "User Two"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 7, 12, 3, 14, 23, 914, DateTimeKind.Utc).AddTicks(5071),
                            Description = "Share tips, reviews, and news about your favorite games",
                            IpAdress = "192.168.1.3",
                            IsAnonymous = false,
                            IsInvisible = false,
                            Title = "Games",
                            UserId = "user3",
                            UserName = "User Three"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2024, 7, 12, 3, 14, 23, 914, DateTimeKind.Utc).AddTicks(5072),
                            Description = "Ask questions and get answers from the community",
                            IpAdress = "192.168.1.4",
                            IsAnonymous = false,
                            IsInvisible = false,
                            Title = "Q&As",
                            UserId = "user4",
                            UserName = "User Four"
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2024, 7, 12, 3, 14, 23, 914, DateTimeKind.Utc).AddTicks(5074),
                            Description = "Stay updated with the latest tech news and gadgets",
                            IpAdress = "192.168.1.5",
                            IsAnonymous = false,
                            IsInvisible = false,
                            Title = "Technology",
                            UserId = "user5",
                            UserName = "User Five"
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2024, 7, 12, 3, 14, 23, 914, DateTimeKind.Utc).AddTicks(5075),
                            Description = "Dive into discussions about music, celebrities, and more",
                            IpAdress = "192.168.1.6",
                            IsAnonymous = false,
                            IsInvisible = false,
                            Title = "Pop Culture",
                            UserId = "user6",
                            UserName = "User Six"
                        },
                        new
                        {
                            Id = 7,
                            CreatedAt = new DateTime(2024, 7, 12, 3, 14, 23, 914, DateTimeKind.Utc).AddTicks(5076),
                            Description = "Discuss the latest movies and TV shows",
                            IpAdress = "192.168.1.7",
                            IsAnonymous = false,
                            IsInvisible = false,
                            Title = "Movie & TV",
                            UserId = "user7",
                            UserName = "User Seven"
                        },
                        new
                        {
                            Id = 8,
                            CreatedAt = new DateTime(2024, 7, 12, 3, 14, 23, 914, DateTimeKind.Utc).AddTicks(5078),
                            Description = "Engage in discussions about current political events",
                            IpAdress = "192.168.1.8",
                            IsAnonymous = false,
                            IsInvisible = false,
                            Title = "Politics",
                            UserId = "user8",
                            UserName = "User Eight"
                        },
                        new
                        {
                            Id = 9,
                            CreatedAt = new DateTime(2024, 7, 12, 3, 14, 23, 914, DateTimeKind.Utc).AddTicks(5079),
                            Description = "Share insights and news about the business world",
                            IpAdress = "192.168.1.9",
                            IsAnonymous = false,
                            IsInvisible = false,
                            Title = "Business",
                            UserId = "user9",
                            UserName = "User Nine"
                        },
                        new
                        {
                            Id = 10,
                            CreatedAt = new DateTime(2024, 7, 12, 3, 14, 23, 914, DateTimeKind.Utc).AddTicks(5080),
                            Description = "Discuss your favorite anime series and movies",
                            IpAdress = "192.168.1.10",
                            IsAnonymous = false,
                            IsInvisible = false,
                            Title = "Anime",
                            UserId = "user10",
                            UserName = "User Ten"
                        });
                });

            modelBuilder.Entity("WisApi.Models.CommentModel", b =>
                {
                    b.HasOne("WisApi.Models.PostModel", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("WisApi.Models.PostModel", b =>
                {
                    b.HasOne("WisApi.Models.TopicModel", "Topic")
                        .WithMany("Posts")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("WisApi.Models.PostModel", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("WisApi.Models.TopicModel", b =>
                {
                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}