using System;

using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogAPI.DataContext.Migrations
{
    public partial class AddBlogTileImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
            {
                throw new ArgumentNullException($"{nameof(migrationBuilder)}");
            }

            _ = migrationBuilder.AddColumn<string>(
                name: "TileImagePath",
                table: "Blogs",
                maxLength: 255,
                nullable: true);

            _ = migrationBuilder.CreateIndex(
                name: "IX_Blogs_Name",
                table: "Blogs",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
            {
                throw new ArgumentNullException($"{nameof(migrationBuilder)}");
            }

            _ = migrationBuilder.DropIndex(
                name: "IX_Blogs_Name",
                table: "Blogs");

            _ = migrationBuilder.DropColumn(
                name: "TileImagePath",
                table: "Blogs");
        }
    }
}
