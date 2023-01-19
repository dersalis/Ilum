using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ilum.Api.Migrations
{
    /// <inheritdoc />
    public partial class _191844 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Users_LeaderId",
                table: "Departments");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Worker");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Departments_LeaderId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "LeaderId",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "ModifiedUserId",
                table: "Users",
                newName: "ModifiedByUserId");

            migrationBuilder.RenameColumn(
                name: "CreateUserId",
                table: "Users",
                newName: "DepartmentId2");

            migrationBuilder.RenameColumn(
                name: "ModifiedUserId",
                table: "Tasks",
                newName: "ModifiedByUserId");

            migrationBuilder.RenameColumn(
                name: "CreateUserId",
                table: "Tasks",
                newName: "CreateByUserId");

            migrationBuilder.RenameColumn(
                name: "ModifiedUserId",
                table: "Departments",
                newName: "ModifiedByUserId1");

            migrationBuilder.RenameColumn(
                name: "CreateUserId",
                table: "Departments",
                newName: "ModifiedByUserId");

            migrationBuilder.AlterColumn<string>(
                name: "LastPassword",
                table: "Users",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CurrentPassword",
                table: "Users",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CreateByUserId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId1",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CreateByUserId",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreateByUserId1",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreateByUserId",
                table: "Users",
                column: "CreateByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DepartmentId1",
                table: "Users",
                column: "DepartmentId1");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DepartmentId2",
                table: "Users",
                column: "DepartmentId2",
                unique: true,
                filter: "[DepartmentId2] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ModifiedByUserId",
                table: "Users",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CreateByUserId",
                table: "Tasks",
                column: "CreateByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ModifiedByUserId",
                table: "Tasks",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CreateByUserId1",
                table: "Departments",
                column: "CreateByUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ModifiedByUserId1",
                table: "Departments",
                column: "ModifiedByUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Users_CreateByUserId1",
                table: "Departments",
                column: "CreateByUserId1",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Users_ModifiedByUserId1",
                table: "Departments",
                column: "ModifiedByUserId1",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_CreateByUserId",
                table: "Tasks",
                column: "CreateByUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_ModifiedByUserId",
                table: "Tasks",
                column: "ModifiedByUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Departments_DepartmentId1",
                table: "Users",
                column: "DepartmentId1",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Departments_DepartmentId2",
                table: "Users",
                column: "DepartmentId2",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_CreateByUserId",
                table: "Users",
                column: "CreateByUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_ModifiedByUserId",
                table: "Users",
                column: "ModifiedByUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Users_CreateByUserId1",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Users_ModifiedByUserId1",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_CreateByUserId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_ModifiedByUserId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Departments_DepartmentId1",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Departments_DepartmentId2",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_CreateByUserId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_ModifiedByUserId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CreateByUserId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_DepartmentId1",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_DepartmentId2",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ModifiedByUserId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_CreateByUserId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_ModifiedByUserId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Departments_CreateByUserId1",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_ModifiedByUserId1",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "CreateByUserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DepartmentId1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreateByUserId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "CreateByUserId1",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "ModifiedByUserId",
                table: "Users",
                newName: "ModifiedUserId");

            migrationBuilder.RenameColumn(
                name: "DepartmentId2",
                table: "Users",
                newName: "CreateUserId");

            migrationBuilder.RenameColumn(
                name: "ModifiedByUserId",
                table: "Tasks",
                newName: "ModifiedUserId");

            migrationBuilder.RenameColumn(
                name: "CreateByUserId",
                table: "Tasks",
                newName: "CreateUserId");

            migrationBuilder.RenameColumn(
                name: "ModifiedByUserId1",
                table: "Departments",
                newName: "ModifiedUserId");

            migrationBuilder.RenameColumn(
                name: "ModifiedByUserId",
                table: "Departments",
                newName: "CreateUserId");

            migrationBuilder.AlterColumn<string>(
                name: "LastPassword",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CurrentPassword",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AddColumn<int>(
                name: "LeaderId",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Worker",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worker", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChangedById = table.Column<int>(type: "int", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemsCount = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Worker_ChangedById",
                        column: x => x.ChangedById,
                        principalTable: "Worker",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Worker_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Worker",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_LeaderId",
                table: "Departments",
                column: "LeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ChangedById",
                table: "Products",
                column: "ChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatedById",
                table: "Products",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Users_LeaderId",
                table: "Departments",
                column: "LeaderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
