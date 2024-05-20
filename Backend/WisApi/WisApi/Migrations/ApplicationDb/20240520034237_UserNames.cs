using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WisApi.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class UserNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Comments");
        }
    }
}
