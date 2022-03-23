using Microsoft.EntityFrameworkCore.Migrations;

namespace PlesniKlubovi.Migrations
{
    public partial class V7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
