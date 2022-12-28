using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Final.Migrations
{
    public partial class Tenplm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chelner",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeChelner = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chelner", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Rezervare",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeRestaurant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumarPersoane = table.Column<int>(type: "int", nullable: false),
                    DataRezervare = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChelnerID = table.Column<int>(type: "int", nullable: true),
                    ClientID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervare", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rezervare_Chelner_ChelnerID",
                        column: x => x.ChelnerID,
                        principalTable: "Chelner",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Rezervare_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rezervare_ChelnerID",
                table: "Rezervare",
                column: "ChelnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervare_ClientID",
                table: "Rezervare",
                column: "ClientID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rezervare");

            migrationBuilder.DropTable(
                name: "Chelner");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
