using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ilum.Api.Migrations
{
    /// <inheritdoc />
    public partial class _191846 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Users_LeaderId1",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_LeaderId1",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "LeaderId1",
                table: "Departments");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Departments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Departments",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_LeaderId",
                table: "Departments",
                column: "LeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Users_LeaderId",
                table: "Departments",
                column: "LeaderId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Users_LeaderId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_LeaderId",
                table: "Departments");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<int>(
                name: "LeaderId1",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_LeaderId1",
                table: "Departments",
                column: "LeaderId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Users_LeaderId1",
                table: "Departments",
                column: "LeaderId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
