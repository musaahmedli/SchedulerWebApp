using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLib.Migrations
{
    public partial class configmanytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Meetings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Meetings",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
