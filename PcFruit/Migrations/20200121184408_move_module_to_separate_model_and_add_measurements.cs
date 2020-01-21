using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PcFruit.Migrations
{
    public partial class move_module_to_separate_model_and_add_measurements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_metingen_Modules_ModuleID",
                table: "metingen");

            migrationBuilder.DropIndex(
                name: "IX_metingen_ModuleID",
                table: "metingen");

            migrationBuilder.DropColumn(
                name: "TimeReceived",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "TimeRegistered",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "ModuleID",
                table: "metingen");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TimeReceived",
                table: "Modules",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeRegistered",
                table: "Modules",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModuleID",
                table: "metingen",
                nullable: true);

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
    }
}
