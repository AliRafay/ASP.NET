using Microsoft.EntityFrameworkCore.Migrations;

namespace Contexts.Migrations
{
    public partial class DescriptionPTVMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PlacesToVisit",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "PlacesToVisit");
        }
    }
}
