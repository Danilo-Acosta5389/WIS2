using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WisApi.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class IsInvisible : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsInvisible",
                table: "Topics",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsInvisible",
                table: "Posts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsInvisible",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "IsInvisible" },
                values: new object[] { new DateTime(2024, 7, 6, 2, 21, 15, 396, DateTimeKind.Utc).AddTicks(7444), false });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IsInvisible" },
                values: new object[] { new DateTime(2024, 7, 6, 2, 21, 15, 396, DateTimeKind.Utc).AddTicks(7447), false });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "IsInvisible" },
                values: new object[] { new DateTime(2024, 7, 6, 2, 21, 15, 396, DateTimeKind.Utc).AddTicks(7449), false });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "IsInvisible" },
                values: new object[] { new DateTime(2024, 7, 6, 2, 21, 15, 396, DateTimeKind.Utc).AddTicks(7450), false });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "IsInvisible" },
                values: new object[] { new DateTime(2024, 7, 6, 2, 21, 15, 396, DateTimeKind.Utc).AddTicks(7451), false });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "IsInvisible" },
                values: new object[] { new DateTime(2024, 7, 6, 2, 21, 15, 396, DateTimeKind.Utc).AddTicks(7453), false });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "IsInvisible" },
                values: new object[] { new DateTime(2024, 7, 6, 2, 21, 15, 396, DateTimeKind.Utc).AddTicks(7454), false });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "IsInvisible" },
                values: new object[] { new DateTime(2024, 7, 6, 2, 21, 15, 396, DateTimeKind.Utc).AddTicks(7455), false });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "IsInvisible" },
                values: new object[] { new DateTime(2024, 7, 6, 2, 21, 15, 396, DateTimeKind.Utc).AddTicks(7457), false });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "IsInvisible" },
                values: new object[] { new DateTime(2024, 7, 6, 2, 21, 15, 396, DateTimeKind.Utc).AddTicks(7458), false });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "IsInvisible" },
                values: new object[] { new DateTime(2024, 7, 6, 2, 21, 15, 396, DateTimeKind.Utc).AddTicks(7307), false });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IsInvisible" },
                values: new object[] { new DateTime(2024, 7, 6, 2, 21, 15, 396, DateTimeKind.Utc).AddTicks(7310), false });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "IsInvisible" },
                values: new object[] { new DateTime(2024, 7, 6, 2, 21, 15, 396, DateTimeKind.Utc).AddTicks(7311), false });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "IsInvisible" },
                values: new object[] { new DateTime(2024, 7, 6, 2, 21, 15, 396, DateTimeKind.Utc).AddTicks(7313), false });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "IsInvisible" },
                values: new object[] { new DateTime(2024, 7, 6, 2, 21, 15, 396, DateTimeKind.Utc).AddTicks(7314), false });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "IsInvisible" },
                values: new object[] { new DateTime(2024, 7, 6, 2, 21, 15, 396, DateTimeKind.Utc).AddTicks(7315), false });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "IsInvisible" },
                values: new object[] { new DateTime(2024, 7, 6, 2, 21, 15, 396, DateTimeKind.Utc).AddTicks(7317), false });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "IsInvisible" },
                values: new object[] { new DateTime(2024, 7, 6, 2, 21, 15, 396, DateTimeKind.Utc).AddTicks(7318), false });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "IsInvisible" },
                values: new object[] { new DateTime(2024, 7, 6, 2, 21, 15, 396, DateTimeKind.Utc).AddTicks(7319), false });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "IsInvisible" },
                values: new object[] { new DateTime(2024, 7, 6, 2, 21, 15, 396, DateTimeKind.Utc).AddTicks(7320), false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInvisible",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "IsInvisible",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "IsInvisible",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 18, 5, 0, 120, DateTimeKind.Utc).AddTicks(4088));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 18, 5, 0, 120, DateTimeKind.Utc).AddTicks(4090));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 18, 5, 0, 120, DateTimeKind.Utc).AddTicks(4096));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 18, 5, 0, 120, DateTimeKind.Utc).AddTicks(4097));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 18, 5, 0, 120, DateTimeKind.Utc).AddTicks(4099));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 18, 5, 0, 120, DateTimeKind.Utc).AddTicks(4439));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 18, 5, 0, 120, DateTimeKind.Utc).AddTicks(4441));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 18, 5, 0, 120, DateTimeKind.Utc).AddTicks(4443));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 18, 5, 0, 120, DateTimeKind.Utc).AddTicks(4445));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 18, 5, 0, 120, DateTimeKind.Utc).AddTicks(4446));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 18, 5, 0, 120, DateTimeKind.Utc).AddTicks(3935));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 18, 5, 0, 120, DateTimeKind.Utc).AddTicks(3940));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 18, 5, 0, 120, DateTimeKind.Utc).AddTicks(3941));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 18, 5, 0, 120, DateTimeKind.Utc).AddTicks(3943));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 18, 5, 0, 120, DateTimeKind.Utc).AddTicks(3944));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 18, 5, 0, 120, DateTimeKind.Utc).AddTicks(3945));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 18, 5, 0, 120, DateTimeKind.Utc).AddTicks(3946));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 18, 5, 0, 120, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 18, 5, 0, 120, DateTimeKind.Utc).AddTicks(3950));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 18, 5, 0, 120, DateTimeKind.Utc).AddTicks(3952));
        }
    }
}
