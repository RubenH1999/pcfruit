using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PcFruit.Migrations
{
    public partial class split_notification_into_notification_settings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_notifications_modules_ModuleID",
                table: "notifications");

            migrationBuilder.DropIndex(
                name: "IX_notifications_ModuleID",
                table: "notifications");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "notifications");

            migrationBuilder.DropColumn(
                name: "MaxRH",
                table: "notifications");

            migrationBuilder.DropColumn(
                name: "MaxTemp",
                table: "notifications");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "notifications");

            migrationBuilder.RenameColumn(
                name: "ModuleID",
                table: "notifications",
                newName: "temp");

            migrationBuilder.RenameColumn(
                name: "MinTemp",
                table: "notifications",
                newName: "RH");

            migrationBuilder.RenameColumn(
                name: "MinRH",
                table: "notifications",
                newName: "NotificationSettingsID");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NotificationSettingsID1",
                table: "notifications",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "notificationSettings",
                columns: table => new
                {
                    NotificationSettingsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NotificationID = table.Column<int>(nullable: false),
                    ModuleID = table.Column<int>(nullable: false),
                    MinTemp = table.Column<int>(nullable: false),
                    MinRH = table.Column<int>(nullable: false),
                    MaxTemp = table.Column<int>(nullable: false),
                    MaxRH = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notificationSettings", x => x.NotificationSettingsID);
                    table.ForeignKey(
                        name: "FK_notificationSettings_modules_ModuleID",
                        column: x => x.ModuleID,
                        principalTable: "modules",
                        principalColumn: "ModuleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_notificationSettings_users_UserID",
                        column: x => x.UserID,
                        principalTable: "users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_notifications_NotificationSettingsID1",
                table: "notifications",
                column: "NotificationSettingsID1");

            migrationBuilder.CreateIndex(
                name: "IX_notificationSettings_ModuleID",
                table: "notificationSettings",
                column: "ModuleID");

            migrationBuilder.CreateIndex(
                name: "IX_notificationSettings_UserID",
                table: "notificationSettings",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_notifications_notificationSettings_NotificationSettingsID1",
                table: "notifications",
                column: "NotificationSettingsID1",
                principalTable: "notificationSettings",
                principalColumn: "NotificationSettingsID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_notifications_notificationSettings_NotificationSettingsID1",
                table: "notifications");

            migrationBuilder.DropTable(
                name: "notificationSettings");

            migrationBuilder.DropIndex(
                name: "IX_notifications_NotificationSettingsID1",
                table: "notifications");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "users");

            migrationBuilder.DropColumn(
                name: "NotificationSettingsID1",
                table: "notifications");

            migrationBuilder.RenameColumn(
                name: "temp",
                table: "notifications",
                newName: "ModuleID");

            migrationBuilder.RenameColumn(
                name: "RH",
                table: "notifications",
                newName: "MinTemp");

            migrationBuilder.RenameColumn(
                name: "NotificationSettingsID",
                table: "notifications",
                newName: "MinRH");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "notifications",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MaxRH",
                table: "notifications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxTemp",
                table: "notifications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "notifications",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_notifications_ModuleID",
                table: "notifications",
                column: "ModuleID");

            migrationBuilder.AddForeignKey(
                name: "FK_notifications_modules_ModuleID",
                table: "notifications",
                column: "ModuleID",
                principalTable: "modules",
                principalColumn: "ModuleID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
