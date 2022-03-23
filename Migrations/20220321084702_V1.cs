using Microsoft.EntityFrameworkCore.Migrations;

namespace PlesniKlubovi.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clanarina",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mesec = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Godina = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clanarina", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Plesni Klub",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Password = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plesni Klub", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Clan Kluba",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JB = table.Column<int>(type: "int", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    DatumRodjenja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kategorija = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PlesniKlubID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clan Kluba", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Clan Kluba_Plesni Klub_PlesniKlubID",
                        column: x => x.PlesniKlubID,
                        principalTable: "Plesni Klub",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ples",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Instruktor = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    PlesniKlubID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ples", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ples_Plesni Klub_PlesniKlubID",
                        column: x => x.PlesniKlubID,
                        principalTable: "Plesni Klub",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClanoviPlesovi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClanarinaID = table.Column<int>(type: "int", nullable: true),
                    ClanKlubaID = table.Column<int>(type: "int", nullable: true),
                    PlesID = table.Column<int>(type: "int", nullable: true),
                    Cena = table.Column<int>(type: "int", nullable: false),
                    PlesniKlubID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClanoviPlesovi", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClanoviPlesovi_Clan Kluba_ClanKlubaID",
                        column: x => x.ClanKlubaID,
                        principalTable: "Clan Kluba",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClanoviPlesovi_Clanarina_ClanarinaID",
                        column: x => x.ClanarinaID,
                        principalTable: "Clanarina",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClanoviPlesovi_Ples_PlesID",
                        column: x => x.PlesID,
                        principalTable: "Ples",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClanoviPlesovi_Plesni Klub_PlesniKlubID",
                        column: x => x.PlesniKlubID,
                        principalTable: "Plesni Klub",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clan Kluba_PlesniKlubID",
                table: "Clan Kluba",
                column: "PlesniKlubID");

            migrationBuilder.CreateIndex(
                name: "IX_ClanoviPlesovi_ClanarinaID",
                table: "ClanoviPlesovi",
                column: "ClanarinaID");

            migrationBuilder.CreateIndex(
                name: "IX_ClanoviPlesovi_ClanKlubaID",
                table: "ClanoviPlesovi",
                column: "ClanKlubaID");

            migrationBuilder.CreateIndex(
                name: "IX_ClanoviPlesovi_PlesID",
                table: "ClanoviPlesovi",
                column: "PlesID");

            migrationBuilder.CreateIndex(
                name: "IX_ClanoviPlesovi_PlesniKlubID",
                table: "ClanoviPlesovi",
                column: "PlesniKlubID");

            migrationBuilder.CreateIndex(
                name: "IX_Ples_PlesniKlubID",
                table: "Ples",
                column: "PlesniKlubID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClanoviPlesovi");

            migrationBuilder.DropTable(
                name: "Clan Kluba");

            migrationBuilder.DropTable(
                name: "Clanarina");

            migrationBuilder.DropTable(
                name: "Ples");

            migrationBuilder.DropTable(
                name: "Plesni Klub");
        }
    }
}
