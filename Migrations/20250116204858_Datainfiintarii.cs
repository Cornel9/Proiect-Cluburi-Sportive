using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Cluburi_Sportive.Migrations
{
    /// <inheritdoc />
    public partial class Datainfiintarii : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataInfiintarii",
                table: "Club",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataInfiintarii",
                table: "Club");
        }
    }
}
