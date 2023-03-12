using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ilum.Domain.Migrations
{
    /// <inheritdoc />
    public partial class _12031612 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 3, 12, 16, 13, 56, 210, DateTimeKind.Local).AddTicks(7870));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "CurrentPassword" },
                values: new object[] { new DateTime(2023, 3, 12, 16, 13, 56, 377, DateTimeKind.Local).AddTicks(1610), "$2a$11$6YHiO/5CqHz97Dee7U/ZguQ9r/nhIbe8ujB2os/m1ZOBIANSYfOJe" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 3, 12, 15, 35, 48, 19, DateTimeKind.Local).AddTicks(9700));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "CurrentPassword" },
                values: new object[] { new DateTime(2023, 3, 12, 15, 35, 48, 185, DateTimeKind.Local).AddTicks(3410), "$2a$11$SjiWy2qGsoGsy4Bzav2YBexlyN8VdNJcMwlByH8PmCkphBrK/JoYS" });
        }
    }
}
