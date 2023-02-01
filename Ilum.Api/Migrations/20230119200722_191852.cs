﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ilum.Api.Migrations
{
    /// <inheritdoc />
    public partial class _191852 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_ResponsibleUserId",
                table: "Tasks");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_ResponsibleUserId",
                table: "Tasks",
                column: "ResponsibleUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_ResponsibleUserId",
                table: "Tasks");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_ResponsibleUserId",
                table: "Tasks",
                column: "ResponsibleUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}