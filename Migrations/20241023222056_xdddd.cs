using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tallerxd.Migrations
{
    /// <inheritdoc />
    public partial class xdddd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Estadio",
                nullable: false,
                defaultValue: DateTime.Now);
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Estadio");
        }
    }
}

