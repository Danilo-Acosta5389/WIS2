using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WisApi.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Url = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    User = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Message = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Ip = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsHandled = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    HandledBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HandledTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IpAdress = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsAnonymous = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsInvisible = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SubTitle = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Text = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UserId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IpAdress = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsAnonymous = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsInvisible = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TopicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Comment = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IpAdress = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsAnonymous = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsInvisible = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "CreatedAt", "Description", "IpAdress", "IsAnonymous", "IsInvisible", "Title", "UpdatedAt", "UserId", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 18, 13, 25, 14, 953, DateTimeKind.Utc).AddTicks(5800), "Discuss anything and everything under the sun", "192.168.1.1", false, false, "General", null, "user1", "User One" },
                    { 2, new DateTime(2024, 7, 18, 13, 25, 14, 953, DateTimeKind.Utc).AddTicks(5803), "Explore the latest trends and memes from the web", "192.168.1.2", false, false, "Internet Culture", null, "user2", "User Two" },
                    { 3, new DateTime(2024, 7, 18, 13, 25, 14, 953, DateTimeKind.Utc).AddTicks(5804), "Share tips, reviews, and news about your favorite games", "192.168.1.3", false, false, "Games", null, "user3", "User Three" },
                    { 4, new DateTime(2024, 7, 18, 13, 25, 14, 953, DateTimeKind.Utc).AddTicks(5805), "Ask questions and get answers from the community", "192.168.1.4", false, false, "Q&As", null, "user4", "User Four" },
                    { 5, new DateTime(2024, 7, 18, 13, 25, 14, 953, DateTimeKind.Utc).AddTicks(5806), "Stay updated with the latest tech news and gadgets", "192.168.1.5", false, false, "Technology", null, "user5", "User Five" },
                    { 6, new DateTime(2024, 7, 18, 13, 25, 14, 953, DateTimeKind.Utc).AddTicks(5808), "Dive into discussions about music, celebrities, and more", "192.168.1.6", false, false, "Pop Culture", null, "user6", "User Six" },
                    { 7, new DateTime(2024, 7, 18, 13, 25, 14, 953, DateTimeKind.Utc).AddTicks(5809), "Discuss the latest movies and TV shows", "192.168.1.7", false, false, "Movie & TV", null, "user7", "User Seven" },
                    { 8, new DateTime(2024, 7, 18, 13, 25, 14, 953, DateTimeKind.Utc).AddTicks(5810), "Engage in discussions about current political events", "192.168.1.8", false, false, "Politics", null, "user8", "User Eight" },
                    { 9, new DateTime(2024, 7, 18, 13, 25, 14, 953, DateTimeKind.Utc).AddTicks(5811), "Share insights and news about the business world", "192.168.1.9", false, false, "Business", null, "user9", "User Nine" },
                    { 10, new DateTime(2024, 7, 18, 13, 25, 14, 953, DateTimeKind.Utc).AddTicks(5812), "Discuss your favorite anime series and movies", "192.168.1.10", false, false, "Anime", null, "user10", "User Ten" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CreatedAt", "IpAdress", "IsAnonymous", "IsInvisible", "SubTitle", "Text", "Title", "TopicId", "UpdatedAt", "UserId", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 18, 13, 25, 14, 953, DateTimeKind.Utc).AddTicks(5923), "192.168.1.1", false, false, null, "Welcome to the forum! Introduce yourself here. What's your name and what brings you to our forum?", "Forum Introduction", 1, null, "user1", "User One" },
                    { 2, new DateTime(2024, 7, 18, 13, 25, 14, 953, DateTimeKind.Utc).AddTicks(5926), "192.168.1.1", false, false, null, "What's on your mind today?", "Daily Thoughts", 1, null, "user1", "User One" },
                    { 3, new DateTime(2024, 7, 18, 13, 25, 14, 953, DateTimeKind.Utc).AddTicks(5928), "192.168.1.1", false, false, null, "Share your favorite hobbies and interests. What hobbies or interests do you enjoy in your free time?", "Hobbies and Interests", 1, null, "user1", "User One" },
                    { 4, new DateTime(2024, 7, 18, 13, 25, 14, 953, DateTimeKind.Utc).AddTicks(5929), "192.168.1.1", false, false, null, "How do you manage your time effectively? What strategies do you use to manage your time effectively?", "Time Management", 1, null, "user1", "User One" },
                    { 5, new DateTime(2024, 7, 18, 13, 25, 14, 953, DateTimeKind.Utc).AddTicks(5930), "192.168.1.1", false, false, null, "What are your goals for this year? What are your main goals for this year and how do you plan to achieve them?", "Yearly Goals", 1, null, "user1", "User One" },
                    { 6, new DateTime(2024, 7, 18, 13, 25, 14, 953, DateTimeKind.Utc).AddTicks(5932), "192.168.1.2", false, false, null, "The funniest memes of 2024. Which meme has made you laugh the most this year?", "Top Memes of 2024", 2, null, "user2", "User Two" },
                    { 7, new DateTime(2024, 7, 18, 13, 25, 14, 953, DateTimeKind.Utc).AddTicks(5933), "192.168.1.2", false, false, null, "Trending hashtags and their origins. What's your favorite trending hashtag and its story?", "Trending Hashtags", 2, null, "user2", "User Two" },
                    { 8, new DateTime(2024, 7, 18, 13, 25, 14, 953, DateTimeKind.Utc).AddTicks(5934), "192.168.1.2", false, false, null, "Internet challenges: Are they safe? Have you tried any internet challenges? Were they safe?", "Internet Challenges", 2, null, "user2", "User Two" },
                    { 9, new DateTime(2024, 7, 18, 13, 25, 14, 953, DateTimeKind.Utc).AddTicks(5935), "192.168.1.2", false, false, null, "Viral videos: What makes them so popular? What elements do you think contribute to a video going viral?", "Viral Videos", 2, null, "user2", "User Two" },
                    { 10, new DateTime(2024, 7, 18, 13, 25, 14, 953, DateTimeKind.Utc).AddTicks(5936), "192.168.1.2", false, false, null, "Online communities you should join. What online communities do you recommend joining and why?", "Online Communities", 2, null, "user2", "User Two" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_TopicId",
                table: "Posts",
                column: "TopicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Topics");
        }
    }
}
