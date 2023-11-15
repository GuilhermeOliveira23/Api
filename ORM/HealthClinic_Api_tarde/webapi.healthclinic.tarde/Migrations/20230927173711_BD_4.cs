using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.healthclinic.tarde.Migrations
{
    /// <inheritdoc />
    public partial class BD_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Paciente");

            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Paciente",
                type: "CHAR(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Telefone",
                table: "Paciente",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "CRM",
                table: "Medico",
                type: "CHAR(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(12)",
                oldMaxLength: 12);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HoraAbertura",
                table: "Clinica",
                type: "TIME",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HoraFechamento",
                table: "Clinica",
                type: "TIME",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "HoraAbertura",
                table: "Clinica");

            migrationBuilder.DropColumn(
                name: "HoraFechamento",
                table: "Clinica");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Paciente",
                type: "VARCHAR(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "CRM",
                table: "Medico",
                type: "VARCHAR(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "CHAR(12)",
                oldMaxLength: 12);
        }
    }
}
