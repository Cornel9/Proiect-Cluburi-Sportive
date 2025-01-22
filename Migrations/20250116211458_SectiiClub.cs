using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Cluburi_Sportive.Migrations
{
    /// <inheritdoc />
    public partial class SectiiClub : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sectie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeSectie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SectieClub",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClubID = table.Column<int>(type: "int", nullable: false),
                    SectieID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectieClub", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SectieClub_Club_ClubID",
                        column: x => x.ClubID,
                        principalTable: "Club",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SectieClub_Sectie_SectieID",
                        column: x => x.SectieID,
                        principalTable: "Sectie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SectieClub_ClubID",
                table: "SectieClub",
                column: "ClubID");

            migrationBuilder.CreateIndex(
                name: "IX_SectieClub_SectieID",
                table: "SectieClub",
                column: "SectieID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SectieClub");

            migrationBuilder.DropTable(
                name: "Sectie");
        }
    }
}
