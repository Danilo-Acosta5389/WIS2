using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WisApi.Migrations
{
    /// <inheritdoc />
    public partial class VerificationCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VerificationCode",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d8a0a9d-2f71-48c5-a2f0-38ec39c4e703",
                columns: new[] { "RefreshTokenExpiry", "VerificationCode" },
                values: new object[] { new DateTime(2024, 8, 9, 20, 43, 34, 773, DateTimeKind.Utc).AddTicks(2999), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VerificationCode",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d8a0a9d-2f71-48c5-a2f0-38ec39c4e703",
                column: "RefreshTokenExpiry",
                value: new DateTime(2024, 7, 12, 5, 57, 9, 318, DateTimeKind.Utc).AddTicks(6226));
        }
    }
}
