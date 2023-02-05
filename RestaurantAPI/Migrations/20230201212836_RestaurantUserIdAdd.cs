using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantAPI.Migrations
{
    public partial class RestaurantUserIdAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Users",
                newName: "DateOfBirth");

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Restaurants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_CreatedById",
                table: "Restaurants",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Users_CreatedById",
                table: "Restaurants",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Users_CreatedById",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_CreatedById",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Restaurants");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "Users",
                newName: "DateTime");
        }
    }
}
