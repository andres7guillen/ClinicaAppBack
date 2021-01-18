using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicaData.Migrations
{
    public partial class ClinicaInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NombreCompleto = table.Column<string>(nullable: true),
                    Especialidad = table.Column<string>(nullable: true),
                    NumeroCredencial = table.Column<string>(nullable: true),
                    HospitalTrabajo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NombreCompleto = table.Column<string>(nullable: true),
                    NumeroSeguroSocial = table.Column<string>(nullable: true),
                    CodigoPostal = table.Column<string>(nullable: true),
                    TelefonoContacto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoctoresPacientes",
                columns: table => new
                {
                    PacienteId = table.Column<Guid>(nullable: false),
                    DoctorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctoresPacientes", x => new { x.DoctorId, x.PacienteId });
                    table.ForeignKey(
                        name: "FK_DoctoresPacientes_Doctores_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctoresPacientes_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctoresPacientes_PacienteId",
                table: "DoctoresPacientes",
                column: "PacienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctoresPacientes");

            migrationBuilder.DropTable(
                name: "Doctores");

            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}
