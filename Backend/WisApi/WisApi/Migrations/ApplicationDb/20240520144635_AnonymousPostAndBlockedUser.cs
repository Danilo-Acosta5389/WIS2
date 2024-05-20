using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WisApi.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class AnonymousPostAndBlockedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAnonymous",
                table: "Topics",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAnonymous",
                table: "Posts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAnonymous",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "IsAnonymous" },
                values: new object[] { new DateTime(2024, 5, 20, 14, 46, 35, 251, DateTimeKind.Utc).AddTicks(619), false });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IsAnonymous" },
                values: new object[] { new DateTime(2024, 5, 20, 14, 46, 35, 251, DateTimeKind.Utc).AddTicks(621), false });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "IsAnonymous" },
                values: new object[] { new DateTime(2024, 5, 20, 14, 46, 35, 251, DateTimeKind.Utc).AddTicks(623), false });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "IsAnonymous" },
                values: new object[] { new DateTime(2024, 5, 20, 14, 46, 35, 251, DateTimeKind.Utc).AddTicks(625), false });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "IsAnonymous" },
                values: new object[] { new DateTime(2024, 5, 20, 14, 46, 35, 251, DateTimeKind.Utc).AddTicks(627), false });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "IsAnonymous" },
                values: new object[] { new DateTime(2024, 5, 20, 14, 46, 35, 251, DateTimeKind.Utc).AddTicks(628), false });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "IsAnonymous" },
                values: new object[] { new DateTime(2024, 5, 20, 14, 46, 35, 251, DateTimeKind.Utc).AddTicks(630), false });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "IsAnonymous" },
                values: new object[] { new DateTime(2024, 5, 20, 14, 46, 35, 251, DateTimeKind.Utc).AddTicks(631), false });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "IsAnonymous" },
                values: new object[] { new DateTime(2024, 5, 20, 14, 46, 35, 251, DateTimeKind.Utc).AddTicks(633), false });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "IsAnonymous" },
                values: new object[] { new DateTime(2024, 5, 20, 14, 46, 35, 251, DateTimeKind.Utc).AddTicks(634), false });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "IsAnonymous" },
                values: new object[] { new DateTime(2024, 5, 20, 14, 46, 35, 251, DateTimeKind.Utc).AddTicks(443), false });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IsAnonymous" },
                values: new object[] { new DateTime(2024, 5, 20, 14, 46, 35, 251, DateTimeKind.Utc).AddTicks(448), false });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "IsAnonymous" },
                values: new object[] { new DateTime(2024, 5, 20, 14, 46, 35, 251, DateTimeKind.Utc).AddTicks(450), false });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "IsAnonymous" },
                values: new object[] { new DateTime(2024, 5, 20, 14, 46, 35, 251, DateTimeKind.Utc).AddTicks(451), false });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "IsAnonymous" },
                values: new object[] { new DateTime(2024, 5, 20, 14, 46, 35, 251, DateTimeKind.Utc).AddTicks(452), false });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "IsAnonymous" },
                values: new object[] { new DateTime(2024, 5, 20, 14, 46, 35, 251, DateTimeKind.Utc).AddTicks(454), false });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "IsAnonymous" },
                values: new object[] { new DateTime(2024, 5, 20, 14, 46, 35, 251, DateTimeKind.Utc).AddTicks(455), false });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "IsAnonymous" },
                values: new object[] { new DateTime(2024, 5, 20, 14, 46, 35, 251, DateTimeKind.Utc).AddTicks(456), false });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "IsAnonymous" },
                values: new object[] { new DateTime(2024, 5, 20, 14, 46, 35, 251, DateTimeKind.Utc).AddTicks(457), false });

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "IsAnonymous" },
                values: new object[] { new DateTime(2024, 5, 20, 14, 46, 35, 251, DateTimeKind.Utc).AddTicks(458), false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAnonymous",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "IsAnonymous",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "IsAnonymous",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 5, 16, 57, 307, DateTimeKind.Utc).AddTicks(4870));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 5, 16, 57, 307, DateTimeKind.Utc).AddTicks(4873));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 5, 16, 57, 307, DateTimeKind.Utc).AddTicks(4875));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 5, 16, 57, 307, DateTimeKind.Utc).AddTicks(4877));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 5, 16, 57, 307, DateTimeKind.Utc).AddTicks(4878));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 5, 16, 57, 307, DateTimeKind.Utc).AddTicks(4879));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 5, 16, 57, 307, DateTimeKind.Utc).AddTicks(4880));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 5, 16, 57, 307, DateTimeKind.Utc).AddTicks(4882));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 5, 16, 57, 307, DateTimeKind.Utc).AddTicks(4883));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 5, 16, 57, 307, DateTimeKind.Utc).AddTicks(4884));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 5, 16, 57, 307, DateTimeKind.Utc).AddTicks(4735));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 5, 16, 57, 307, DateTimeKind.Utc).AddTicks(4738));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 5, 16, 57, 307, DateTimeKind.Utc).AddTicks(4740));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 5, 16, 57, 307, DateTimeKind.Utc).AddTicks(4741));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 5, 16, 57, 307, DateTimeKind.Utc).AddTicks(4742));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 5, 16, 57, 307, DateTimeKind.Utc).AddTicks(4743));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 5, 16, 57, 307, DateTimeKind.Utc).AddTicks(4745));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 5, 16, 57, 307, DateTimeKind.Utc).AddTicks(4746));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 5, 16, 57, 307, DateTimeKind.Utc).AddTicks(4747));

            migrationBuilder.UpdateData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 20, 5, 16, 57, 307, DateTimeKind.Utc).AddTicks(4748));
        }
    }
}
