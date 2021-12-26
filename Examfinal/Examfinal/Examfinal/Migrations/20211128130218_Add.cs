using Microsoft.EntityFrameworkCore.Migrations;

namespace Examfinal.Migrations
{
    public partial class Add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_roles_accounts_AccountId",
                table: "roles");

            migrationBuilder.DropIndex(
                name: "IX_roles_AccountId",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "roles");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Phone",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "ContactCategory",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AccountRole",
                columns: table => new
                {
                    RolesId = table.Column<int>(type: "int", nullable: false),
                    accountsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountRole", x => new { x.RolesId, x.accountsId });
                    table.ForeignKey(
                        name: "FK_AccountRole_accounts_accountsId",
                        column: x => x.accountsId,
                        principalTable: "accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountRole_roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Phone_AccountId",
                table: "Phone",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactCategory_AccountId",
                table: "ContactCategory",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountRole_accountsId",
                table: "AccountRole",
                column: "accountsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactCategory_accounts_AccountId",
                table: "ContactCategory",
                column: "AccountId",
                principalTable: "accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Phone_accounts_AccountId",
                table: "Phone",
                column: "AccountId",
                principalTable: "accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactCategory_accounts_AccountId",
                table: "ContactCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_Phone_accounts_AccountId",
                table: "Phone");

            migrationBuilder.DropTable(
                name: "AccountRole");

            migrationBuilder.DropIndex(
                name: "IX_Phone_AccountId",
                table: "Phone");

            migrationBuilder.DropIndex(
                name: "IX_ContactCategory_AccountId",
                table: "ContactCategory");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Phone");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "ContactCategory");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "roles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_roles_AccountId",
                table: "roles",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_roles_accounts_AccountId",
                table: "roles",
                column: "AccountId",
                principalTable: "accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
