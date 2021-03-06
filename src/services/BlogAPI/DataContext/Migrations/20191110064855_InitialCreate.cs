﻿using System;

using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogAPI.DataContext.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
            {
                throw new ArgumentNullException($"{nameof(migrationBuilder)}");
            }

            _ = migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new {
                    BlogId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table => table.PrimaryKey("PK_Blogs", x => x.BlogId));

            _ = migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new {
                    PostId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BlogId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    RawContent = table.Column<string>(type: "TEXT", nullable: true),
                    ParsedContent = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table => {
                    _ = table.PrimaryKey("PK_Posts", x => x.PostId);
                    _ = table.ForeignKey(
                        name: "FK_Posts_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "BlogId",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateIndex(
                name: "IX_Posts_BlogId",
                table: "Posts",
                column: "BlogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder == null)
            {
                throw new ArgumentNullException($"{nameof(migrationBuilder)}");
            }

            _ = migrationBuilder.DropTable(
                name: "Posts");

            _ = migrationBuilder.DropTable(
                name: "Blogs");
        }
    }
}
