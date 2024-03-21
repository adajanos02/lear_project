using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lear_project.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodList",
                table: "FoodList");

            migrationBuilder.RenameTable(
                name: "FoodList",
                newName: "Food");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Food",
                table: "Food",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Food",
                table: "Food");

            migrationBuilder.RenameTable(
                name: "Food",
                newName: "FoodList");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodList",
                table: "FoodList",
                column: "Id");
        }
    }
}
