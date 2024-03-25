using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lear_project.Migrations
{
    public partial class orderlist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrderId",
                table: "FoodList",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderList",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderList", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodList_OrderId",
                table: "FoodList",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodList_OrderList_OrderId",
                table: "FoodList",
                column: "OrderId",
                principalTable: "OrderList",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodList_OrderList_OrderId",
                table: "FoodList");

            migrationBuilder.DropTable(
                name: "OrderList");

            migrationBuilder.DropIndex(
                name: "IX_FoodList_OrderId",
                table: "FoodList");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "FoodList");
        }
    }
}
