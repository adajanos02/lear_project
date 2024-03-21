using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lear_project.Migrations
{
    public partial class baseupd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "FoodList");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "FoodList",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "FoodList",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "FoodList",
                type: "BLOB",
                nullable: true);
        }
    }
}
