using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Motorcycle.Migrations
{
    /// <inheritdoc />
    public partial class ManyToOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycles_Brends_BrendId",
                table: "Motorcycles");

            migrationBuilder.AlterColumn<int>(
                name: "BrendId",
                table: "Motorcycles",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Motorcycles_Brends_BrendId",
                table: "Motorcycles",
                column: "BrendId",
                principalTable: "Brends",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycles_Brends_BrendId",
                table: "Motorcycles");

            migrationBuilder.AlterColumn<int>(
                name: "BrendId",
                table: "Motorcycles",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Motorcycles_Brends_BrendId",
                table: "Motorcycles",
                column: "BrendId",
                principalTable: "Brends",
                principalColumn: "Id");
        }
    }
}
