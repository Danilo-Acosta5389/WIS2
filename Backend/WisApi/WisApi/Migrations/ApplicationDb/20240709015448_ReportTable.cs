using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WisApi.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class ReportTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsHandled = table.Column<bool>(type: "bit", nullable: false),
                    HandledBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HandledTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 9, 1, 54, 47, 663, DateTimeKind.Utc).AddTicks(8798));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 9, 1, 54, 47, 663, DateTimeKind.Utc).AddTicks(8801));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 9, 1, 54, 47, 663, DateTimeKind.Utc).AddTicks(8803));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 9, 1, 54, 47, 663, DateTimeKind.Utc).AddTicks(8804));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 9, 1, 54, 47, 663, DateTimeKind.Utc).AddTicks(8806));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 9, 1, 54, 47, 663, DateTimeKind.Utc).AddTicks(8807));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 9, 1, 54, 47, 663, DateTimeKind.Utc).AddTicks(8808));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 9, 1, 54, 47, 663, DateTimeKind.Utc).AddTicks(8810));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 9, 1, 54, 47, 663, DateTimeKind.Utc).AddTicks(8811));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 9, 1, 54, 47, 663, DateTimeKind.Utc).AddTicks(8812));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 9, 1, 54, 47, 663, DateTimeKind.Utc).AddTicks(8664));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 9, 1, 54, 47, 663, DateTimeKind.Utc).AddTicks(8667));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 9, 1, 54, 47, 663, DateTimeKind.Utc).AddTicks(8668));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 9, 1, 54, 47, 663, DateTimeKind.Utc).AddTicks(8670));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 9, 1, 54, 47, 663, DateTimeKind.Utc).AddTicks(8671));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 9, 1, 54, 47, 663, DateTimeKind.Utc).AddTicks(8672));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 9, 1, 54, 47, 663, DateTimeKind.Utc).AddTicks(8674));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 9, 1, 54, 47, 663, DateTimeKind.Utc).AddTicks(8675));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 9, 1, 54, 47, 663, DateTimeKind.Utc).AddTicks(8676));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 9, 1, 54, 47, 663, DateTimeKind.Utc).AddTicks(8677));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 6, 2, 21, 15, 396, DateTimeKind.Utc).AddTicks(7444));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 6, 2, 21, 15, 396, DateTimeKind.Utc).AddTicks(7447));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 6, 2, 21, 15, 396, DateTimeKind.Utc).AddTicks(7449));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 6, 2, 21, 15, 396, DateTimeKind.Utc).AddTicks(7450));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 6, 2, 21, 15, 396, DateTimeKind.Utc).AddTicks(7451));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 6, 2, 21, 15, 396, DateTimeKind.Utc).AddTicks(7453));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 6, 2, 21, 15, 396, DateTimeKind.Utc).AddTicks(7454));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 6, 2, 21, 15, 396, DateTimeKind.Utc).AddTicks(7455));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 6, 2, 21, 15, 396, DateTimeKind.Utc).AddTicks(7457));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 6, 2, 21, 15, 396, DateTimeKind.Utc).AddTicks(7458));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 6, 2, 21, 15, 396, DateTimeKind.Utc).AddTicks(7307));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 6, 2, 21, 15, 396, DateTimeKind.Utc).AddTicks(7310));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 6, 2, 21, 15, 396, DateTimeKind.Utc).AddTicks(7311));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 6, 2, 21, 15, 396, DateTimeKind.Utc).AddTicks(7313));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 6, 2, 21, 15, 396, DateTimeKind.Utc).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 6, 2, 21, 15, 396, DateTimeKind.Utc).AddTicks(7315));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 6, 2, 21, 15, 396, DateTimeKind.Utc).AddTicks(7317));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 6, 2, 21, 15, 396, DateTimeKind.Utc).AddTicks(7318));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 6, 2, 21, 15, 396, DateTimeKind.Utc).AddTicks(7319));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 6, 2, 21, 15, 396, DateTimeKind.Utc).AddTicks(7320));
        }
    }
}
