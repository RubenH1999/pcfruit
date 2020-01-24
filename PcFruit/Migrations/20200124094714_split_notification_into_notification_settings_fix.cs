using Microsoft.EntityFrameworkCore.Migrations;

namespace PcFruit.Migrations
{
    public partial class split_notification_into_notification_settings_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_notifications_notificationSettings_NotificationSettingsID1",
                table: "notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_notifications_users_UserID",
                table: "notifications");

            migrationBuilder.DropIndex(
                name: "IX_notifications_NotificationSettingsID1",
                table: "notifications");

            migrationBuilder.DropIndex(
                name: "IX_notifications_UserID",
                table: "notifications");

            migrationBuilder.DropColumn(
                name: "NotificationID",
                table: "notificationSettings");

            migrationBuilder.DropColumn(
                name: "NotificationSettingsID1",
                table: "notifications");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "notifications");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_NotificationSettingsID",
                table: "notifications",
                column: "NotificationSettingsID");

            migrationBuilder.AddForeignKey(
                name: "FK_notifications_notificationSettings_NotificationSettingsID",
                table: "notifications",
                column: "NotificationSettingsID",
                principalTable: "notificationSettings",
                principalColumn: "NotificationSettingsID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_notifications_notificationSettings_NotificationSettingsID",
                table: "notifications");

            migrationBuilder.DropIndex(
                name: "IX_notifications_NotificationSettingsID",
                table: "notifications");

            migrationBuilder.AddColumn<int>(
                name: "NotificationID",
                table: "notificationSettings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NotificationSettingsID1",
                table: "notifications",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "notifications",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_notifications_NotificationSettingsID1",
                table: "notifications",
                column: "NotificationSettingsID1");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_UserID",
                table: "notifications",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_notifications_notificationSettings_NotificationSettingsID1",
                table: "notifications",
                column: "NotificationSettingsID1",
                principalTable: "notificationSettings",
                principalColumn: "NotificationSettingsID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_notifications_users_UserID",
                table: "notifications",
                column: "UserID",
                principalTable: "users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
