using Microsoft.EntityFrameworkCore.Migrations;

namespace PcFruit.Migrations
{
    public partial class add_salt_to_user_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                table: "User");
        }
    }
}
