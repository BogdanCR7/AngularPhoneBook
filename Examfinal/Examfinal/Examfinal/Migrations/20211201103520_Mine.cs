using Microsoft.EntityFrameworkCore.Migrations;

namespace Examfinal.Migrations
{
    public partial class Mine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_accounts_AccountId",
                table: "Contact");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactCategory_accounts_AccountId",
                table: "ContactCategory");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Phone");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "ContactCategory",
                newName: "AdderId");

            migrationBuilder.RenameIndex(
                name: "IX_ContactCategory_AccountId",
                table: "ContactCategory",
                newName: "IX_ContactCategory_AdderId");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Contact",
                newName: "AdderId");

            migrationBuilder.RenameIndex(
                name: "IX_Contact_AccountId",
                table: "Contact",
                newName: "IX_Contact_AdderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_accounts_AdderId",
                table: "Contact",
                column: "AdderId",
                principalTable: "accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactCategory_accounts_AdderId",
                table: "ContactCategory",
                column: "AdderId",
                principalTable: "accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_accounts_AdderId",
                table: "Contact");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactCategory_accounts_AdderId",
                table: "ContactCategory");

            migrationBuilder.RenameColumn(
                name: "AdderId",
                table: "ContactCategory",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_ContactCategory_AdderId",
                table: "ContactCategory",
                newName: "IX_ContactCategory_AccountId");

            migrationBuilder.RenameColumn(
                name: "AdderId",
                table: "Contact",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Contact_AdderId",
                table: "Contact",
                newName: "IX_Contact_AccountId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Phone",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_accounts_AccountId",
                table: "Contact",
                column: "AccountId",
                principalTable: "accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactCategory_accounts_AccountId",
                table: "ContactCategory",
                column: "AccountId",
                principalTable: "accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
