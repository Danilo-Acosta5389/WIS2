using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WisApi.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Text", "Title", "UserName" },
                values: new object[] { new DateTime(2024, 5, 20, 5, 16, 57, 307, DateTimeKind.Utc).AddTicks(4870), "Welcome to the forum! Introduce yourself here. What's your name and what brings you to our forum?", "Forum Introduction", "User One" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IpAdress", "SubTitle", "Text", "Title", "TopicId", "UserId", "UserName" },
                values: new object[] { new DateTime(2024, 5, 20, 5, 16, 57, 307, DateTimeKind.Utc).AddTicks(4873), "192.168.1.1", null, "What's on your mind today?", "Daily Thoughts", 1, "user1", "User One" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CreatedAt", "IpAdress", "SubTitle", "Text", "Title", "TopicId", "UpdatedAt", "UserId", "UserName" },
                values: new object[,]
                {
                    { 3, new DateTime(2024, 5, 20, 5, 16, 57, 307, DateTimeKind.Utc).AddTicks(4875), "192.168.1.1", null, "Share your favorite hobbies and interests. What hobbies or interests do you enjoy in your free time?", "Hobbies and Interests", 1, null, "user1", "User One" },
                    { 4, new DateTime(2024, 5, 20, 5, 16, 57, 307, DateTimeKind.Utc).AddTicks(4877), "192.168.1.1", null, "How do you manage your time effectively? What strategies do you use to manage your time effectively?", "Time Management", 1, null, "user1", "User One" },
                    { 5, new DateTime(2024, 5, 20, 5, 16, 57, 307, DateTimeKind.Utc).AddTicks(4878), "192.168.1.1", null, "What are your goals for this year? What are your main goals for this year and how do you plan to achieve them?", "Yearly Goals", 1, null, "user1", "User One" },
                    { 6, new DateTime(2024, 5, 20, 5, 16, 57, 307, DateTimeKind.Utc).AddTicks(4879), "192.168.1.2", null, "The funniest memes of 2024. Which meme has made you laugh the most this year?", "Top Memes of 2024", 2, null, "user2", "User Two" },
                    { 7, new DateTime(2024, 5, 20, 5, 16, 57, 307, DateTimeKind.Utc).AddTicks(4880), "192.168.1.2", null, "Trending hashtags and their origins. What's your favorite trending hashtag and its story?", "Trending Hashtags", 2, null, "user2", "User Two" },
                    { 8, new DateTime(2024, 5, 20, 5, 16, 57, 307, DateTimeKind.Utc).AddTicks(4882), "192.168.1.2", null, "Internet challenges: Are they safe? Have you tried any internet challenges? Were they safe?", "Internet Challenges", 2, null, "user2", "User Two" },
                    { 9, new DateTime(2024, 5, 20, 5, 16, 57, 307, DateTimeKind.Utc).AddTicks(4883), "192.168.1.2", null, "Viral videos: What makes them so popular? What elements do you think contribute to a video going viral?", "Viral Videos", 2, null, "user2", "User Two" },
                    { 10, new DateTime(2024, 5, 20, 5, 16, 57, 307, DateTimeKind.Utc).AddTicks(4884), "192.168.1.2", null, "Online communities you should join. What online communities do you recommend joining and why?", "Online Communities", 2, null, "user2", "User Two" }
                });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UserName" },
                values: new object[] { new DateTime(2024, 5, 20, 5, 16, 57, 307, DateTimeKind.Utc).AddTicks(4735), "User One" });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "Title", "UserName" },
                values: new object[] { new DateTime(2024, 5, 20, 5, 16, 57, 307, DateTimeKind.Utc).AddTicks(4738), "Explore the latest trends and memes from the web", "Internet Culture", "User Two" });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "CreatedAt", "Description", "IpAdress", "Title", "UpdatedAt", "UserId", "UserName" },
                values: new object[,]
                {
                    { 3, new DateTime(2024, 5, 20, 5, 16, 57, 307, DateTimeKind.Utc).AddTicks(4740), "Share tips, reviews, and news about your favorite games", "192.168.1.3", "Games", null, "user3", "User Three" },
                    { 4, new DateTime(2024, 5, 20, 5, 16, 57, 307, DateTimeKind.Utc).AddTicks(4741), "Ask questions and get answers from the community", "192.168.1.4", "Q&As", null, "user4", "User Four" },
                    { 5, new DateTime(2024, 5, 20, 5, 16, 57, 307, DateTimeKind.Utc).AddTicks(4742), "Stay updated with the latest tech news and gadgets", "192.168.1.5", "Technology", null, "user5", "User Five" },
                    { 6, new DateTime(2024, 5, 20, 5, 16, 57, 307, DateTimeKind.Utc).AddTicks(4743), "Dive into discussions about music, celebrities, and more", "192.168.1.6", "Pop Culture", null, "user6", "User Six" },
                    { 7, new DateTime(2024, 5, 20, 5, 16, 57, 307, DateTimeKind.Utc).AddTicks(4745), "Discuss the latest movies and TV shows", "192.168.1.7", "Movie & TV", null, "user7", "User Seven" },
                    { 8, new DateTime(2024, 5, 20, 5, 16, 57, 307, DateTimeKind.Utc).AddTicks(4746), "Engage in discussions about current political events", "192.168.1.8", "Politics", null, "user8", "User Eight" },
                    { 9, new DateTime(2024, 5, 20, 5, 16, 57, 307, DateTimeKind.Utc).AddTicks(4747), "Share insights and news about the business world", "192.168.1.9", "Business", null, "user9", "User Nine" },
                    { 10, new DateTime(2024, 5, 20, 5, 16, 57, 307, DateTimeKind.Utc).AddTicks(4748), "Discuss your favorite anime series and movies", "192.168.1.10", "Anime", null, "user10", "User Ten" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedAt", "IpAdress", "PostId", "UpdatedAt", "UserId", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 20, 4, 24, 13, 284, DateTimeKind.Utc).AddTicks(9322), "192.168.1.3", 1, null, "user3", "UserThree" },
                    { 2, new DateTime(2024, 5, 20, 4, 24, 13, 284, DateTimeKind.Utc).AddTicks(9323), "192.168.1.4", 2, null, "user4", "UserFour" }
                });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Text", "Title", "UserName" },
                values: new object[] { new DateTime(2024, 5, 20, 4, 24, 13, 284, DateTimeKind.Utc).AddTicks(9297), "Feel free to discuss anything here.", "Welcome to the General Forum", "UserOne" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IpAdress", "SubTitle", "Text", "Title", "TopicId", "UserId", "UserName" },
                values: new object[] { new DateTime(2024, 5, 20, 4, 24, 13, 284, DateTimeKind.Utc).AddTicks(9300), "192.168.1.2", "Latest updates", "Share and discuss the latest in tech news.", "Tech News", 2, "user2", "UserTwo" });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UserName" },
                values: new object[] { new DateTime(2024, 5, 20, 4, 24, 13, 284, DateTimeKind.Utc).AddTicks(9175), "UserOne" });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "Title", "UserName" },
                values: new object[] { new DateTime(2024, 5, 20, 4, 24, 13, 284, DateTimeKind.Utc).AddTicks(9178), "Discuss the latest in tech", "Technology", "UserTwo" });
        }
    }
}
