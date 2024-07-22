using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WisApi.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class ReportType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Reports",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 16, 34, 54, 539, DateTimeKind.Utc).AddTicks(609));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 16, 34, 54, 539, DateTimeKind.Utc).AddTicks(612));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 16, 34, 54, 539, DateTimeKind.Utc).AddTicks(613));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 16, 34, 54, 539, DateTimeKind.Utc).AddTicks(614));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 16, 34, 54, 539, DateTimeKind.Utc).AddTicks(616));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 16, 34, 54, 539, DateTimeKind.Utc).AddTicks(618));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 16, 34, 54, 539, DateTimeKind.Utc).AddTicks(619));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 16, 34, 54, 539, DateTimeKind.Utc).AddTicks(621));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 16, 34, 54, 539, DateTimeKind.Utc).AddTicks(622));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 16, 34, 54, 539, DateTimeKind.Utc).AddTicks(623));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 16, 34, 54, 539, DateTimeKind.Utc).AddTicks(425));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 16, 34, 54, 539, DateTimeKind.Utc).AddTicks(428));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 16, 34, 54, 539, DateTimeKind.Utc).AddTicks(429));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 16, 34, 54, 539, DateTimeKind.Utc).AddTicks(431));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 16, 34, 54, 539, DateTimeKind.Utc).AddTicks(432));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 16, 34, 54, 539, DateTimeKind.Utc).AddTicks(433));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 16, 34, 54, 539, DateTimeKind.Utc).AddTicks(435));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 16, 34, 54, 539, DateTimeKind.Utc).AddTicks(436));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 16, 34, 54, 539, DateTimeKind.Utc).AddTicks(437));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 16, 34, 54, 539, DateTimeKind.Utc).AddTicks(438));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Reports");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 13, 25, 14, 953, DateTimeKind.Utc).AddTicks(5923));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 13, 25, 14, 953, DateTimeKind.Utc).AddTicks(5926));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 13, 25, 14, 953, DateTimeKind.Utc).AddTicks(5928));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 13, 25, 14, 953, DateTimeKind.Utc).AddTicks(5929));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 13, 25, 14, 953, DateTimeKind.Utc).AddTicks(5930));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 13, 25, 14, 953, DateTimeKind.Utc).AddTicks(5932));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 13, 25, 14, 953, DateTimeKind.Utc).AddTicks(5933));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 13, 25, 14, 953, DateTimeKind.Utc).AddTicks(5934));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 13, 25, 14, 953, DateTimeKind.Utc).AddTicks(5935));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 13, 25, 14, 953, DateTimeKind.Utc).AddTicks(5936));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 13, 25, 14, 953, DateTimeKind.Utc).AddTicks(5800));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 13, 25, 14, 953, DateTimeKind.Utc).AddTicks(5803));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 13, 25, 14, 953, DateTimeKind.Utc).AddTicks(5804));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 13, 25, 14, 953, DateTimeKind.Utc).AddTicks(5805));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 13, 25, 14, 953, DateTimeKind.Utc).AddTicks(5806));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 13, 25, 14, 953, DateTimeKind.Utc).AddTicks(5808));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 13, 25, 14, 953, DateTimeKind.Utc).AddTicks(5809));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 13, 25, 14, 953, DateTimeKind.Utc).AddTicks(5810));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 13, 25, 14, 953, DateTimeKind.Utc).AddTicks(5811));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 13, 25, 14, 953, DateTimeKind.Utc).AddTicks(5812));
        }
    }
}
