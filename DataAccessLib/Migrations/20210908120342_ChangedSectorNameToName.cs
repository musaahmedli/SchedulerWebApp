using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLib.Migrations
{
    public partial class ChangedSectorNameToName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SectorName",
                table: "Sectors",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Sectors",
                newName: "SectorName");
        }
    }
}
