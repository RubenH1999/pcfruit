using Microsoft.EntityFrameworkCore.Migrations;

namespace PcFruit.Migrations
{
    public partial class tables_to_lowercase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measurements_Modules_ModuleID",
                table: "Measurements");

            migrationBuilder.DropForeignKey(
                name: "FK_metingen_Measurements_MeasurementID",
                table: "metingen");

            migrationBuilder.DropForeignKey(
                name: "FK_Notification_Modules_ModuleID",
                table: "Notification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Modules",
                table: "Modules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notification",
                table: "Notification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_metingen",
                table: "metingen");

            migrationBuilder.RenameTable(
                name: "Modules",
                newName: "modules");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Notification",
                newName: "notifications");

            migrationBuilder.RenameTable(
                name: "metingen",
                newName: "sensors");

            migrationBuilder.RenameIndex(
                name: "IX_Notification_ModuleID",
                table: "notifications",
                newName: "IX_notifications_ModuleID");

            migrationBuilder.RenameIndex(
                name: "IX_metingen_MeasurementID",
                table: "sensors",
                newName: "IX_sensors_MeasurementID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_modules",
                table: "modules",
                column: "ModuleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_notifications",
                table: "notifications",
                column: "NotificationID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sensors",
                table: "sensors",
                column: "SensorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Measurements_modules_ModuleID",
                table: "Measurements",
                column: "ModuleID",
                principalTable: "modules",
                principalColumn: "ModuleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_notifications_modules_ModuleID",
                table: "notifications",
                column: "ModuleID",
                principalTable: "modules",
                principalColumn: "ModuleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sensors_Measurements_MeasurementID",
                table: "sensors",
                column: "MeasurementID",
                principalTable: "Measurements",
                principalColumn: "MeasurementID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measurements_modules_ModuleID",
                table: "Measurements");

            migrationBuilder.DropForeignKey(
                name: "FK_notifications_modules_ModuleID",
                table: "notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_sensors_Measurements_MeasurementID",
                table: "sensors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_modules",
                table: "modules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sensors",
                table: "sensors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_notifications",
                table: "notifications");

            migrationBuilder.RenameTable(
                name: "modules",
                newName: "Modules");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "sensors",
                newName: "metingen");

            migrationBuilder.RenameTable(
                name: "notifications",
                newName: "Notification");

            migrationBuilder.RenameIndex(
                name: "IX_sensors_MeasurementID",
                table: "metingen",
                newName: "IX_metingen_MeasurementID");

            migrationBuilder.RenameIndex(
                name: "IX_notifications_ModuleID",
                table: "Notification",
                newName: "IX_Notification_ModuleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Modules",
                table: "Modules",
                column: "ModuleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_metingen",
                table: "metingen",
                column: "SensorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notification",
                table: "Notification",
                column: "NotificationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Measurements_Modules_ModuleID",
                table: "Measurements",
                column: "ModuleID",
                principalTable: "Modules",
                principalColumn: "ModuleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_metingen_Measurements_MeasurementID",
                table: "metingen",
                column: "MeasurementID",
                principalTable: "Measurements",
                principalColumn: "MeasurementID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_Modules_ModuleID",
                table: "Notification",
                column: "ModuleID",
                principalTable: "Modules",
                principalColumn: "ModuleID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
