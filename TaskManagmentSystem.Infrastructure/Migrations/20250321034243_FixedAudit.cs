using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagmentSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixedAudit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskHistories_Tasks_ChangedByUserId",
                table: "TaskHistories");

            migrationBuilder.DropIndex(
                name: "IX_TaskHistories_ChangedByUserId",
                table: "TaskHistories");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskHistories_Tasks_Id",
                table: "TaskHistories",
                column: "Id",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskHistories_Tasks_Id",
                table: "TaskHistories");

            migrationBuilder.CreateIndex(
                name: "IX_TaskHistories_ChangedByUserId",
                table: "TaskHistories",
                column: "ChangedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskHistories_Tasks_ChangedByUserId",
                table: "TaskHistories",
                column: "ChangedByUserId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
