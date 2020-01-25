using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SecureServer.Migrations
{
    public partial class usercanbeblocked : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Attempt",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Blockade",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Attempt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Blockade",
                table: "Users");
        }
    }
}
