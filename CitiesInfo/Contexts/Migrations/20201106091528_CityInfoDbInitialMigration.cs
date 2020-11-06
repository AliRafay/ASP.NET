using Microsoft.EntityFrameworkCore.Migrations;

namespace Contexts.Migrations
{
    public partial class CityInfoDbInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)  //for current to new version migration
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlacesToVisit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacesToVisit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlacesToVisit_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlacesToVisit_CityId",
                table: "PlacesToVisit",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder) //from current to previous version migrations
        {
            migrationBuilder.DropTable(
                name: "PlacesToVisit");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
