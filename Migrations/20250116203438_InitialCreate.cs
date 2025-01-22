using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Cluburi_Sportive.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Club",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manager = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valoare = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Club", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Club");
        }
    }
}
