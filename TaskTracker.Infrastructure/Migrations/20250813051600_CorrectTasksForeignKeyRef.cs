using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CorrectTasksForeignKeyRef : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_AssignedToUserId",
                table: "UserTasks",
                column: "AssignedToUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_Users_AssignedToUserId",
                table: "UserTasks",
                column: "AssignedToUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_Users_AssignedToUserId",
                table: "UserTasks");

            migrationBuilder.DropIndex(
                name: "IX_UserTasks_AssignedToUserId",
                table: "UserTasks");
        }
    }
}
