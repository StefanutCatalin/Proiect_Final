using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Final.Migrations
{
    public partial class categoriemancare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeCategorie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CategorieMancare",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RezervareID = table.Column<int>(type: "int", nullable: false),
                    CategorieID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieMancare", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CategorieMancare_Categorie_CategorieID",
                        column: x => x.CategorieID,
                        principalTable: "Categorie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorieMancare_Rezervare_RezervareID",
                        column: x => x.RezervareID,
                        principalTable: "Rezervare",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategorieMancare_CategorieID",
                table: "CategorieMancare",
                column: "CategorieID");

            migrationBuilder.CreateIndex(
                name: "IX_CategorieMancare_RezervareID",
                table: "CategorieMancare",
                column: "RezervareID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategorieMancare");

            migrationBuilder.DropTable(
                name: "Categorie");
        }
    }
}
