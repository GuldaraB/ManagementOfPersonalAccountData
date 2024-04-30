using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagementOfPersonalAccountData.Migrations
{
    public partial class ResidentPersonalAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resident_PersonalAccounts_PersonalAccountId",
                table: "Resident");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resident",
                table: "Resident");

            migrationBuilder.RenameTable(
                name: "Resident",
                newName: "Residents");

            migrationBuilder.RenameIndex(
                name: "IX_Resident_PersonalAccountId",
                table: "Residents",
                newName: "IX_Residents_PersonalAccountId");

            migrationBuilder.AlterColumn<int>(
                name: "PersonalAccountId",
                table: "Residents",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Residents",
                table: "Residents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Residents_PersonalAccounts_PersonalAccountId",
                table: "Residents",
                column: "PersonalAccountId",
                principalTable: "PersonalAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Residents_PersonalAccounts_PersonalAccountId",
                table: "Residents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Residents",
                table: "Residents");

            migrationBuilder.RenameTable(
                name: "Residents",
                newName: "Resident");

            migrationBuilder.RenameIndex(
                name: "IX_Residents_PersonalAccountId",
                table: "Resident",
                newName: "IX_Resident_PersonalAccountId");

            migrationBuilder.AlterColumn<int>(
                name: "PersonalAccountId",
                table: "Resident",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resident",
                table: "Resident",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Resident_PersonalAccounts_PersonalAccountId",
                table: "Resident",
                column: "PersonalAccountId",
                principalTable: "PersonalAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
