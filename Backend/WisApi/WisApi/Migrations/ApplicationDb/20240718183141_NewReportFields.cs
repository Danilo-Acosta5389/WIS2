using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WisApi.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class NewReportFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User",
                table: "Reports",
                newName: "ReportedBy");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Reports",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "ReportedItemId",
                table: "Reports",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReportedUser",
                table: "Reports",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 18, 31, 41, 318, DateTimeKind.Utc).AddTicks(1548));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 18, 31, 41, 318, DateTimeKind.Utc).AddTicks(1550));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 18, 31, 41, 318, DateTimeKind.Utc).AddTicks(1552));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 18, 31, 41, 318, DateTimeKind.Utc).AddTicks(1554));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 18, 31, 41, 318, DateTimeKind.Utc).AddTicks(1556));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 18, 31, 41, 318, DateTimeKind.Utc).AddTicks(1557));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 18, 31, 41, 318, DateTimeKind.Utc).AddTicks(1558));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 18, 31, 41, 318, DateTimeKind.Utc).AddTicks(1560));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 18, 31, 41, 318, DateTimeKind.Utc).AddTicks(1561));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 18, 31, 41, 318, DateTimeKind.Utc).AddTicks(1562));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 18, 31, 41, 318, DateTimeKind.Utc).AddTicks(1401));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 18, 31, 41, 318, DateTimeKind.Utc).AddTicks(1407));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 18, 31, 41, 318, DateTimeKind.Utc).AddTicks(1408));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 18, 31, 41, 318, DateTimeKind.Utc).AddTicks(1409));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 18, 31, 41, 318, DateTimeKind.Utc).AddTicks(1410));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 18, 31, 41, 318, DateTimeKind.Utc).AddTicks(1412));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 18, 31, 41, 318, DateTimeKind.Utc).AddTicks(1413));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 18, 31, 41, 318, DateTimeKind.Utc).AddTicks(1414));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 18, 31, 41, 318, DateTimeKind.Utc).AddTicks(1415));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 18, 31, 41, 318, DateTimeKind.Utc).AddTicks(1417));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportedItemId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ReportedUser",
                table: "Reports");

            migrationBuilder.RenameColumn(
                name: "ReportedBy",
                table: "Reports",
                newName: "User");

            migrationBuilder.UpdateData(
                table: "Reports",
                keyColumn: "Url",
                keyValue: null,
                column: "Url",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Reports",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

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
    }
}
