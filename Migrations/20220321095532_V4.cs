using Microsoft.EntityFrameworkCore.Migrations;

namespace PlesniKlubovi.Migrations
{
    public partial class V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ples_Plesni Klub_PlesniKlubID",
                table: "Ples");

            migrationBuilder.DropIndex(
                name: "IX_Ples_PlesniKlubID",
                table: "Ples");

            migrationBuilder.DropColumn(
                name: "PlesniKlubID",
                table: "Ples");

            migrationBuilder.CreateTable(
                name: "PlesPlesniKlub",
                columns: table => new
                {
                    PlesniKlubID = table.Column<int>(type: "int", nullable: false),
                    PlesoviID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlesPlesniKlub", x => new { x.PlesniKlubID, x.PlesoviID });
                    table.ForeignKey(
                        name: "FK_PlesPlesniKlub_Ples_PlesoviID",
                        column: x => x.PlesoviID,
                        principalTable: "Ples",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlesPlesniKlub_Plesni Klub_PlesniKlubID",
                        column: x => x.PlesniKlubID,
                        principalTable: "Plesni Klub",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlesPlesniKlub_PlesoviID",
                table: "PlesPlesniKlub",
                column: "PlesoviID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlesPlesniKlub");

            migrationBuilder.AddColumn<int>(
                name: "PlesniKlubID",
                table: "Ples",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ples_PlesniKlubID",
                table: "Ples",
                column: "PlesniKlubID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ples_Plesni Klub_PlesniKlubID",
                table: "Ples",
                column: "PlesniKlubID",
                principalTable: "Plesni Klub",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
