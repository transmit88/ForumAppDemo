﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumAppDemo.Migrations
{
    /// <inheritdoc />
    public partial class IdDeletedFlagAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Posts",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Mark record as delete");

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Posts");
        }
    }
}
