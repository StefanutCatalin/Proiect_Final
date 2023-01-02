using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Final.Migrations
{
    public partial class Structura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Angajat",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Restaurant = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Angajat", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Structura",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AngajatID = table.Column<int>(type: "int", nullable: true),
                    RezervareID = table.Column<int>(type: "int", nullable: true),
                    DataRezervare = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Masa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Structura", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Structura_Angajat_AngajatID",
                        column: x => x.AngajatID,
                        principalTable: "Angajat",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Structura_Rezervare_RezervareID",
                        column: x => x.RezervareID,
                        principalTable: "Rezervare",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Structura_AngajatID",
                table: "Structura",
                column: "AngajatID");

            migrationBuilder.CreateIndex(
                name: "IX_Structura_RezervareID",
                table: "Structura",
                column: "RezervareID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Structura");

            migrationBuilder.DropTable(
                name: "Angajat");
        }
    }
}
