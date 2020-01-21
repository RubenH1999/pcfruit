using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PcFruit.Migrations
{
    public partial class change_meter_model_name_to_module : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MeterID",
                table: "metingen",
                newName: "SensorID");

            migrationBuilder.AddColumn<int>(
                name: "ModuleID",
                table: "metingen",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    ModuleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    TimeReceived = table.Column<DateTime>(nullable: false),
                    TimeRegistered = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.ModuleID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_metingen_ModuleID",
                table: "metingen",
                column: "ModuleID");

            migrationBuilder.AddForeignKey(
                name: "FK_metingen_Modules_ModuleID",
                table: "metingen",
                column: "ModuleID",
                principalTable: "Modules",
                principalColumn: "ModuleID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_metingen_Modules_ModuleID",
                table: "metingen");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropIndex(
                name: "IX_metingen_ModuleID",
                table: "metingen");

            migrationBuilder.DropColumn(
                name: "ModuleID",
                table: "metingen");

            migrationBuilder.RenameColumn(
                name: "SensorID",
                table: "metingen",
                newName: "MeterID");
        }
    }
}
