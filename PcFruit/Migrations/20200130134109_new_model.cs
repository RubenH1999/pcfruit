using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PcFruit.Migrations
{
    public partial class new_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measurements_modules_ModuleID",
                table: "Measurements");

            migrationBuilder.DropForeignKey(
                name: "FK_sensors_Measurements_MeasurementID",
                table: "sensors");

            migrationBuilder.DropTable(
                name: "notifications");

            migrationBuilder.DropTable(
                name: "notificationSettings");

            migrationBuilder.DropIndex(
                name: "IX_sensors_MeasurementID",
                table: "sensors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Measurements",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "hasAccess",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Analog",
                table: "sensors");

            migrationBuilder.DropColumn(
                name: "Distance",
                table: "sensors");

            migrationBuilder.DropColumn(
                name: "Humidity",
                table: "sensors");

            migrationBuilder.DropColumn(
                name: "MeasurementID",
                table: "sensors");

            migrationBuilder.DropColumn(
                name: "Resistance",
                table: "sensors");

            migrationBuilder.DropColumn(
                name: "Temperature",
                table: "sensors");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "sensors");

            migrationBuilder.DropColumn(
                name: "Voltage",
                table: "sensors");

            migrationBuilder.RenameTable(
                name: "Measurements",
                newName: "measurements");

            migrationBuilder.RenameColumn(
                name: "Voornaam",
                table: "users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Naam",
                table: "users",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Label",
                table: "sensors",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_Measurements_ModuleID",
                table: "measurements",
                newName: "IX_measurements_ModuleID");

            migrationBuilder.AlterColumn<long>(
                name: "UserID",
                table: "users",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<long>(
                name: "ModuleID",
                table: "users",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "SensorID",
                table: "sensors",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "SensorType",
                table: "sensors",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<long>(
                name: "ModuleID",
                table: "modules",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<long>(
                name: "ModuleID",
                table: "measurements",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "MeasurementID",
                table: "measurements",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<long>(
                name: "SensorID",
                table: "measurements",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "SpecID",
                table: "measurements",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<double>(
                name: "Value",
                table: "measurements",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_measurements",
                table: "measurements",
                column: "MeasurementID");

            migrationBuilder.CreateTable(
                name: "sensorspecs",
                columns: table => new
                {
                    SpecID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Min = table.Column<double>(nullable: false),
                    Max = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sensorspecs", x => x.SpecID);
                });

            migrationBuilder.CreateTable(
                name: "SensorSpec",
                columns: table => new
                {
                    SensorID = table.Column<long>(nullable: false),
                    SpecID = table.Column<long>(nullable: false),
                    SensorSpecID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorSpec", x => new { x.SpecID, x.SensorID });
                    table.ForeignKey(
                        name: "FK_SensorSpec_sensors_SensorID",
                        column: x => x.SensorID,
                        principalTable: "sensors",
                        principalColumn: "SensorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SensorSpec_sensorspecs_SpecID",
                        column: x => x.SpecID,
                        principalTable: "sensorspecs",
                        principalColumn: "SpecID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_ModuleID",
                table: "users",
                column: "ModuleID");

            migrationBuilder.CreateIndex(
                name: "IX_measurements_SensorID",
                table: "measurements",
                column: "SensorID");

            migrationBuilder.CreateIndex(
                name: "IX_measurements_SpecID",
                table: "measurements",
                column: "SpecID");

            migrationBuilder.CreateIndex(
                name: "IX_SensorSpec_SensorID",
                table: "SensorSpec",
                column: "SensorID");

            migrationBuilder.AddForeignKey(
                name: "FK_measurements_modules_ModuleID",
                table: "measurements",
                column: "ModuleID",
                principalTable: "modules",
                principalColumn: "ModuleID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_measurements_sensors_SensorID",
                table: "measurements",
                column: "SensorID",
                principalTable: "sensors",
                principalColumn: "SensorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_measurements_sensorspecs_SpecID",
                table: "measurements",
                column: "SpecID",
                principalTable: "sensorspecs",
                principalColumn: "SpecID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_modules_ModuleID",
                table: "users",
                column: "ModuleID",
                principalTable: "modules",
                principalColumn: "ModuleID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_measurements_modules_ModuleID",
                table: "measurements");

            migrationBuilder.DropForeignKey(
                name: "FK_measurements_sensors_SensorID",
                table: "measurements");

            migrationBuilder.DropForeignKey(
                name: "FK_measurements_sensorspecs_SpecID",
                table: "measurements");

            migrationBuilder.DropForeignKey(
                name: "FK_users_modules_ModuleID",
                table: "users");

            migrationBuilder.DropTable(
                name: "SensorSpec");

            migrationBuilder.DropTable(
                name: "sensorspecs");

            migrationBuilder.DropIndex(
                name: "IX_users_ModuleID",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_measurements",
                table: "measurements");

            migrationBuilder.DropIndex(
                name: "IX_measurements_SensorID",
                table: "measurements");

            migrationBuilder.DropIndex(
                name: "IX_measurements_SpecID",
                table: "measurements");

            migrationBuilder.DropColumn(
                name: "ModuleID",
                table: "users");

            migrationBuilder.DropColumn(
                name: "SensorType",
                table: "sensors");

            migrationBuilder.DropColumn(
                name: "SensorID",
                table: "measurements");

            migrationBuilder.DropColumn(
                name: "SpecID",
                table: "measurements");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "measurements");

            migrationBuilder.RenameTable(
                name: "measurements",
                newName: "Measurements");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "users",
                newName: "Voornaam");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "users",
                newName: "Naam");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "sensors",
                newName: "Label");

            migrationBuilder.RenameIndex(
                name: "IX_measurements_ModuleID",
                table: "Measurements",
                newName: "IX_Measurements_ModuleID");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "users",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<bool>(
                name: "hasAccess",
                table: "users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "SensorID",
                table: "sensors",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "Analog",
                table: "sensors",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Distance",
                table: "sensors",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Humidity",
                table: "sensors",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MeasurementID",
                table: "sensors",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Resistance",
                table: "sensors",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Temperature",
                table: "sensors",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "sensors",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Voltage",
                table: "sensors",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ModuleID",
                table: "modules",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "ModuleID",
                table: "Measurements",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "MeasurementID",
                table: "Measurements",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Measurements",
                table: "Measurements",
                column: "MeasurementID");

            migrationBuilder.CreateTable(
                name: "notificationSettings",
                columns: table => new
                {
                    NotificationSettingsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsActive = table.Column<bool>(nullable: false),
                    MaxRH = table.Column<int>(nullable: false),
                    MaxTemp = table.Column<int>(nullable: false),
                    MinRH = table.Column<int>(nullable: false),
                    MinTemp = table.Column<int>(nullable: false),
                    ModuleID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "notifications",
                columns: table => new
                {
                    NotificationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NotificationSettingsID = table.Column<int>(nullable: false),
                    RH = table.Column<int>(nullable: false),
                    Temp = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notifications", x => x.NotificationID);
                    table.ForeignKey(
                        name: "FK_notifications_notificationSettings_NotificationSettingsID",
                        column: x => x.NotificationSettingsID,
                        principalTable: "notificationSettings",
                        principalColumn: "NotificationSettingsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sensors_MeasurementID",
                table: "sensors",
                column: "MeasurementID");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_NotificationSettingsID",
                table: "notifications",
                column: "NotificationSettingsID");

            migrationBuilder.CreateIndex(
                name: "IX_notificationSettings_ModuleID",
                table: "notificationSettings",
                column: "ModuleID");

            migrationBuilder.CreateIndex(
                name: "IX_notificationSettings_UserID",
                table: "notificationSettings",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Measurements_modules_ModuleID",
                table: "Measurements",
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
    }
}
