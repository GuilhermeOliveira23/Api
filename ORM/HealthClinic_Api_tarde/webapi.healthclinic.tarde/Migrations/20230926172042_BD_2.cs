using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.healthclinic.tarde.Migrations
{
    /// <inheritdoc />
    public partial class BD_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataAgendamento",
                table: "Consulta",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAgendamento",
                table: "Consulta");
        }
    }
}
