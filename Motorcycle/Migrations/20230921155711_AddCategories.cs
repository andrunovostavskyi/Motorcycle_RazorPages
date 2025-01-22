using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Motorcycle.Migrations
{
    /// <inheritdoc />
    public partial class AddCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Motorcycles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycles_CategoryId",
                table: "Motorcycles",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Motorcycles_Categories_CategoryId",
                table: "Motorcycles",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycles_Categories_CategoryId",
                table: "Motorcycles");

            migrationBuilder.DropIndex(
                name: "IX_Motorcycles_CategoryId",
                table: "Motorcycles");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Motorcycles");
        }
    }
}
