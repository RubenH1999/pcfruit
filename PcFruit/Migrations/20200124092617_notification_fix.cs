using Microsoft.EntityFrameworkCore.Migrations;

namespace PcFruit.Migrations
{
    public partial class notification_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "temp",
                table: "notifications",
                newName: "Temp");

            migrationBuilder.AddColumn<bool>(
                name: "hasAccess",
                table: "users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "notifications",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_notifications_UserID",
                table: "notifications",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_notifications_users_UserID",
                table: "notifications",
                column: "UserID",
                principalTable: "users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_notifications_users_UserID",
                table: "notifications");

            migrationBuilder.DropIndex(
                name: "IX_notifications_UserID",
                table: "notifications");

            migrationBuilder.DropColumn(
                name: "hasAccess",
                table: "users");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "notifications");

            migrationBuilder.RenameColumn(
                name: "Temp",
                table: "notifications",
                newName: "temp");
        }
    }
}
