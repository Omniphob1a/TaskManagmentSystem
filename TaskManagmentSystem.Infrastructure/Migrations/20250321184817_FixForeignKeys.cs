using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagmentSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskHistories_Tasks_Id",
                table: "TaskHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskHistories_Users_Id",
                table: "TaskHistories");

            migrationBuilder.AddColumn<Guid>(
                name: "TaskId",
                table: "TaskHistories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_TaskHistories_ChangedByUserId",
                table: "TaskHistories",
                column: "ChangedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskHistories_TaskId",
                table: "TaskHistories",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskHistories_Tasks_TaskId",
                table: "TaskHistories",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskHistories_Users_ChangedByUserId",
                table: "TaskHistories",
                column: "ChangedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskHistories_Tasks_TaskId",
                table: "TaskHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskHistories_Users_ChangedByUserId",
                table: "TaskHistories");

            migrationBuilder.DropIndex(
                name: "IX_TaskHistories_ChangedByUserId",
                table: "TaskHistories");

            migrationBuilder.DropIndex(
                name: "IX_TaskHistories_TaskId",
                table: "TaskHistories");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "TaskHistories");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskHistories_Tasks_Id",
                table: "TaskHistories",
                column: "Id",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskHistories_Users_Id",
                table: "TaskHistories",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
