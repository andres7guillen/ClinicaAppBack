﻿// <auto-generated />
using System;
using ClinicaData.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClinicaData.Migrations
{
    [DbContext(typeof(ClinicaContext))]
    [Migration("20210117232630_ClinicaInit")]
    partial class ClinicaInit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClinicaData.Entities.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Especialidad");

                    b.Property<string>("HospitalTrabajo");

                    b.Property<string>("NombreCompleto");

                    b.Property<string>("NumeroCredencial");

                    b.HasKey("Id");

                    b.ToTable("Doctores");
                });

            modelBuilder.Entity("ClinicaData.Entities.DoctorPaciente", b =>
                {
                    b.Property<Guid>("DoctorId");

                    b.Property<Guid>("PacienteId");

                    b.HasKey("DoctorId", "PacienteId");

                    b.HasIndex("PacienteId");

                    b.ToTable("DoctoresPacientes");
                });

            modelBuilder.Entity("ClinicaData.Entities.Paciente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CodigoPostal");

                    b.Property<string>("NombreCompleto");

                    b.Property<string>("NumeroSeguroSocial");

                    b.Property<string>("TelefonoContacto");

                    b.HasKey("Id");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("ClinicaData.Entities.DoctorPaciente", b =>
                {
                    b.HasOne("ClinicaData.Entities.Doctor", "Doctor")
                        .WithMany("DoctoresPacientes")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ClinicaData.Entities.Paciente", "Paciente")
                        .WithMany("DoctoresPacientes")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}