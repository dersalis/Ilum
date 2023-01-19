using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ilum.Api.Migrations
{
    /// <inheritdoc />
    public partial class _191840 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Worker_ChangedById",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Worker_CreatedById",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Worker_ChangedById",
                table: "Products",
                column: "ChangedById",
                principalTable: "Worker",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Worker_CreatedById",
                table: "Products",
                column: "CreatedById",
                principalTable: "Worker",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Worker_ChangedById",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Worker_CreatedById",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Products");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Worker_ChangedById",
                table: "Products",
                column: "ChangedById",
                principalTable: "Worker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Worker_CreatedById",
                table: "Products",
                column: "CreatedById",
                principalTable: "Worker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
