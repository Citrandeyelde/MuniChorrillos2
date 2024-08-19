using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MuniChorrillos2.Migrations
{
    /// <inheritdoc />
    public partial class AgregarTelefonoYObservacionesAMultum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                 name: "Telefono",
                 table: "Multa",
                 type: "int",
                 maxLength: 9,
                 nullable: false,
                 defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Observaciones",
                table: "Multa",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Multa");

            migrationBuilder.DropColumn(
                name: "Observaciones",
                table: "Multa");
        }
    }
}
