using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogAPI.DataContext.Migrations
{
    public partial class AddBlogTileImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TileImagePath",
                table: "Blogs",
                maxLength: 255,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_Name",
                table: "Blogs",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Blogs_Name",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "TileImagePath",
                table: "Blogs");
        }
    }
}
