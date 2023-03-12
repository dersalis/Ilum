using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ilum.Domain.Migrations
{
    /// <inheritdoc />
    public partial class _12031534 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 3, 12, 15, 7, 22, 168, DateTimeKind.Local).AddTicks(3750));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "CurrentPassword" },
                values: new object[] { new DateTime(2023, 3, 12, 15, 7, 22, 334, DateTimeKind.Local).AddTicks(7980), "$2a$11$ih22QsdGM28FbFzsthfh1.qehSKOJKnX.toTcu1BFIewZYwsbaqZS" });
        }
    }
}
