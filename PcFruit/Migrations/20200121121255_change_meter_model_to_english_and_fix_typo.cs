using Microsoft.EntityFrameworkCore.Migrations;

namespace PcFruit.Migrations
{
    public partial class change_meter_model_to_english_and_fix_typo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Volgtage",
                table: "metingen");

            migrationBuilder.RenameColumn(
                name: "Vochtigheid",
                table: "metingen",
                newName: "Temperature");

            migrationBuilder.RenameColumn(
                name: "Temperatuur",
                table: "metingen",
                newName: "Humidity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Temperature",
                table: "metingen",
                newName: "Vochtigheid");

            migrationBuilder.RenameColumn(
                name: "Humidity",
                table: "metingen",
                newName: "Temperatuur");

            migrationBuilder.AddColumn<int>(
                name: "Volgtage",
                table: "metingen",
                nullable: false,
                defaultValue: 0);
        }
    }
}
