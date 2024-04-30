using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagementOfPersonalAccountData.Migrations
{
    public partial class Resident : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Fatherland",
                table: "Resident",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Resident",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fatherland",
                table: "Resident");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Resident");
        }
    }
}
