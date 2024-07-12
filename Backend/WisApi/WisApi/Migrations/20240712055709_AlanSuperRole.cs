using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WisApi.Migrations
{
    /// <inheritdoc />
    public partial class AlanSuperRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Bio", "ConcurrencyStamp", "Email", "EmailConfirmed", "ImageName", "IsBlocked", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PublicId", "RefreshToken", "RefreshTokenExpiry", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6d8a0a9d-2f71-48c5-a2f0-38ec39c4e703", 0, "Pioneering mathematician and logician, I developed the Turing machine concept and broke the Enigma code in WWII. My work laid the foundations for computer science and artificial intelligence. Passionate about mathematics and cryptography.", "e8dc401f-24d8-45b5-85af-1091a93fa5dc", "alan@example.com", false, "", false, true, null, "ALAN@EXAMPLE.COM", null, "AQAAAAIAAYagAAAAEIetXl7p1Ttix+2XzMxdrW8+tjzcUBUcgvb30e+YJInUDavI4XvLRSe21bT6aT1HFA==", null, false, "b3f7ad63-e494-4cf4-82b1-118d8ebd4545", "", new DateTime(2024, 7, 12, 5, 57, 9, 318, DateTimeKind.Utc).AddTicks(6226), "GRDTK2VAAUGEO3H2ZVBOR4FRUU3EIWUE", false, "turing-c0mplete" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a54ace02-d2ea-4fea-9bc3-60c95f18fb0b", "6d8a0a9d-2f71-48c5-a2f0-38ec39c4e703" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a54ace02-d2ea-4fea-9bc3-60c95f18fb0b", "6d8a0a9d-2f71-48c5-a2f0-38ec39c4e703" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d8a0a9d-2f71-48c5-a2f0-38ec39c4e703");
        }
    }
}
