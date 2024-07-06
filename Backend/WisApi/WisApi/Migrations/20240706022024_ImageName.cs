using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WisApi.Migrations
{
    /// <inheritdoc />
    public partial class ImageName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "AspNetUsers",
                newName: "ImageName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "AspNetUsers",
                newName: "Image");
        }
    }
}
