using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GalleryApi.Migrations
{
    /// <inheritdoc />
    public partial class PicturesMigrationUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "PicturesDbSet",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "PicturesDbSet");
        }
    }
}
