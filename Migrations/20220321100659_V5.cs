using Microsoft.EntityFrameworkCore.Migrations;

namespace PlesniKlubovi.Migrations
{
    public partial class V5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlesPlesniKlub");

            migrationBuilder.AddColumn<int>(
                name: "PlesID",
                table: "Plesni Klub",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plesni Klub_PlesID",
                table: "Plesni Klub",
                column: "PlesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Plesni Klub_Ples_PlesID",
                table: "Plesni Klub",
                column: "PlesID",
                principalTable: "Ples",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plesni Klub_Ples_PlesID",
                table: "Plesni Klub");

            migrationBuilder.DropIndex(
                name: "IX_Plesni Klub_PlesID",
                table: "Plesni Klub");

            migrationBuilder.DropColumn(
                name: "PlesID",
                table: "Plesni Klub");

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
    }
}
