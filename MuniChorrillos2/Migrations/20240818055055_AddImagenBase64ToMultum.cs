using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MuniChorrillos2.Migrations
{
    /// <inheritdoc />
    public partial class AddImagenBase64ToMultum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagenBase64",
                table: "Multa",
                type: "varchar(max)",
                unicode: false,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagenBase64",
                table: "Multa");
        }
    }
}
