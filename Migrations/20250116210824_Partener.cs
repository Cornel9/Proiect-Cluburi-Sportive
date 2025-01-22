using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Cluburi_Sportive.Migrations
{
    /// <inheritdoc />
    public partial class Partener : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PartenerID",
                table: "Club",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Partener",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumePartener = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partener", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Club_PartenerID",
                table: "Club",
                column: "PartenerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Club_Partener_PartenerID",
                table: "Club",
                column: "PartenerID",
                principalTable: "Partener",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Club_Partener_PartenerID",
                table: "Club");

            migrationBuilder.DropTable(
                name: "Partener");

            migrationBuilder.DropIndex(
                name: "IX_Club_PartenerID",
                table: "Club");

            migrationBuilder.DropColumn(
                name: "PartenerID",
                table: "Club");
        }
    }
}
