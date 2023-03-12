using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ilum.Domain.Migrations
{
    /// <inheritdoc />
    public partial class _12031454 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastPassword",
                table: "Users",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AddColumn<bool>(
                name: "IsManager",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreateByUserId", "CreateDate", "Description", "IsActive", "ModifiedByUserId", "ModifiedDate", "Name" },
                values: new object[] { 1, null, new DateTime(2023, 3, 12, 15, 7, 22, 168, DateTimeKind.Local).AddTicks(3750), "IT Department", true, null, null, "IT" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateByUserId", "CreateDate", "CurrentPassword", "DepartmentId", "Email", "FirstName", "IsActive", "LastName", "LastPassword", "Login", "ModifiedByUserId", "ModifiedDate" },
                values: new object[] { 1, null, new DateTime(2023, 3, 12, 15, 7, 22, 334, DateTimeKind.Local).AddTicks(7980), "$2a$11$ih22QsdGM28FbFzsthfh1.qehSKOJKnX.toTcu1BFIewZYwsbaqZS", 1, "admin@wp.pl", "Administrator", true, "Administrator", null, "admin", null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "IsManager",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "LastPassword",
                table: "Users",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64,
                oldNullable: true);
        }
    }
}
