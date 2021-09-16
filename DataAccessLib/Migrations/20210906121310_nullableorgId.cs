using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLib.Migrations
{
    public partial class nullableorgId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Organizations_ParentOrganizationId",
                table: "Organizations");

            migrationBuilder.AlterColumn<int>(
                name: "ParentOrganizationId",
                table: "Organizations",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Organizations_ParentOrganizationId",
                table: "Organizations",
                column: "ParentOrganizationId",
                principalTable: "Organizations",
                principalColumn: "OrganizationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Organizations_ParentOrganizationId",
                table: "Organizations");

            migrationBuilder.AlterColumn<int>(
                name: "ParentOrganizationId",
                table: "Organizations",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Organizations_ParentOrganizationId",
                table: "Organizations",
                column: "ParentOrganizationId",
                principalTable: "Organizations",
                principalColumn: "OrganizationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
