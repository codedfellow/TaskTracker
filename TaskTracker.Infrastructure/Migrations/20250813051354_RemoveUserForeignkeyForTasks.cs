using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUserForeignkeyForTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTasks_Users_AssignedToId",
                table: "UserTasks");

            migrationBuilder.DropIndex(
                name: "IX_UserTasks_AssignedToId",
                table: "UserTasks");

            migrationBuilder.DropColumn(
                name: "AssignedToId",
                table: "UserTasks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AssignedToId",
                table: "UserTasks",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_UserTasks_AssignedToId",
                table: "UserTasks",
                column: "AssignedToId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTasks_Users_AssignedToId",
                table: "UserTasks",
                column: "AssignedToId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
