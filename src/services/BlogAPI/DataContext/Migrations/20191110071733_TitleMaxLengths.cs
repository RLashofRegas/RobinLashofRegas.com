using System;

using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogAPI.DataContext.Migrations
{
    public partial class TitleMaxLengths : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
            {
                throw new ArgumentNullException($"{nameof(migrationBuilder)}");
            }

            _ = migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                maxLength: 48,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");

            _ = migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Blogs",
                maxLength: 48,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
            {
                throw new ArgumentNullException($"{nameof(migrationBuilder)}");
            }

            _ = migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 48);

            _ = migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Blogs",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 48);
        }
    }
}
