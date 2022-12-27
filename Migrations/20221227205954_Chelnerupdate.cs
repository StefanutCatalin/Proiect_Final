using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Final.Migrations
{
    public partial class Chelnerupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChelnerID",
                table: "Rezervare",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Rezervare_ChelnerID",
                table: "Rezervare",
                column: "ChelnerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervare_Chelner_ChelnerID",
                table: "Rezervare",
                column: "ChelnerID",
                principalTable: "Chelner",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervare_Chelner_ChelnerID",
                table: "Rezervare");

            migrationBuilder.DropTable(
                name: "Chelner");

            migrationBuilder.DropIndex(
                name: "IX_Rezervare_ChelnerID",
                table: "Rezervare");

            migrationBuilder.DropColumn(
                name: "ChelnerID",
                table: "Rezervare");
        }
    }
}
