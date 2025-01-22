using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Cluburi_Sportive.Migrations
{
    /// <inheritdoc />
    public partial class competitie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompetitieID",
                table: "Club",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Competitie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeCompetitie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitie", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Club_CompetitieID",
                table: "Club",
                column: "CompetitieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Club_Competitie_CompetitieID",
                table: "Club",
                column: "CompetitieID",
                principalTable: "Competitie",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Club_Competitie_CompetitieID",
                table: "Club");

            migrationBuilder.DropTable(
                name: "Competitie");

            migrationBuilder.DropIndex(
                name: "IX_Club_CompetitieID",
                table: "Club");

            migrationBuilder.DropColumn(
                name: "CompetitieID",
                table: "Club");
        }
    }
}
