using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PcFruit.Migrations
{
    public partial class fix_measurement_props : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MeasurementID",
                table: "metingen",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Measurements",
                columns: table => new
                {
                    MeasurementID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ModuleID = table.Column<int>(nullable: false),
                    TimeReceived = table.Column<DateTime>(nullable: false),
                    TimeRegistered = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurements", x => x.MeasurementID);
                    table.ForeignKey(
                        name: "FK_Measurements_Modules_ModuleID",
                        column: x => x.ModuleID,
                        principalTable: "Modules",
                        principalColumn: "ModuleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_metingen_MeasurementID",
                table: "metingen",
                column: "MeasurementID");

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_ModuleID",
                table: "Measurements",
                column: "ModuleID");

            migrationBuilder.AddForeignKey(
                name: "FK_metingen_Measurements_MeasurementID",
                table: "metingen",
                column: "MeasurementID",
                principalTable: "Measurements",
                principalColumn: "MeasurementID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_metingen_Measurements_MeasurementID",
                table: "metingen");

            migrationBuilder.DropTable(
                name: "Measurements");

            migrationBuilder.DropIndex(
                name: "IX_metingen_MeasurementID",
                table: "metingen");

            migrationBuilder.DropColumn(
                name: "MeasurementID",
                table: "metingen");
        }
    }
}
