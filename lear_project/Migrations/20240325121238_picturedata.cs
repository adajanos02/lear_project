using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lear_project.Migrations
{
    public partial class picturedata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "FoodList",
                type: "BLOB",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "FoodList");
        }
    }
}
