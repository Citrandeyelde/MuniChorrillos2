using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MuniChorrillos2.Migrations
{
    /// <inheritdoc />
    public partial class AddMontoMultaToMultum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MontoMulta",
                table: "Multa",
                type: "decimal(18,2)", // Ajusta el tipo de datos según tus necesidades
                nullable: false,
                defaultValue: 0m); // Establecer un valor por defecto
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MontoMulta",
                table: "Multa");
        }
    }
}
