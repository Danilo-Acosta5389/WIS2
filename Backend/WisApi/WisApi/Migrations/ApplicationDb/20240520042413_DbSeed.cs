using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WisApi.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class DbSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "CreatedAt", "Description", "IpAdress", "Title", "UpdatedAt", "UserId", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 20, 4, 24, 13, 284, DateTimeKind.Utc).AddTicks(9175), "Discuss anything and everything under the sun", "192.168.1.1", "General", null, "user1", "UserOne" },
                    { 2, new DateTime(2024, 5, 20, 4, 24, 13, 284, DateTimeKind.Utc).AddTicks(9178), "Discuss the latest in tech", "192.168.1.2", "Technology", null, "user2", "UserTwo" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CreatedAt", "IpAdress", "SubTitle", "Text", "Title", "TopicId", "UpdatedAt", "UserId", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 20, 4, 24, 13, 284, DateTimeKind.Utc).AddTicks(9297), "192.168.1.1", null, "Feel free to discuss anything here.", "Welcome to the General Forum", 1, null, "user1", "UserOne" },
                    { 2, new DateTime(2024, 5, 20, 4, 24, 13, 284, DateTimeKind.Utc).AddTicks(9300), "192.168.1.2", "Latest updates", "Share and discuss the latest in tech news.", "Tech News", 2, null, "user2", "UserTwo" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedAt", "IpAdress", "PostId", "UpdatedAt", "UserId", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 20, 4, 24, 13, 284, DateTimeKind.Utc).AddTicks(9322), "192.168.1.3", 1, null, "user3", "UserThree" },
                    { 2, new DateTime(2024, 5, 20, 4, 24, 13, 284, DateTimeKind.Utc).AddTicks(9323), "192.168.1.4", 2, null, "user4", "UserFour" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
