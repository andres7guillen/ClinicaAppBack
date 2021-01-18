using ClinicaAPI.Models;
using ClinicaData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaAPI.Converts
{
    public static class PacienteConvert
    {
        public static Paciente toEntity(PacienteModel input)
        {
            Paciente output = new Paciente();            
            output.Id = input.Id != null ? output.Id = Guid.Parse(input.Id) : output.Id = Guid.Empty;
            output.NombreCompleto = input.NombreCompleto != null ? output.NombreCompleto = input.NombreCompleto : output.NombreCompleto = "-o-";
            output.NumeroSeguroSocial = input.NumeroSeguroSocial != null ? output.NumeroSeguroSocial = input.NumeroSeguroSocial : output.NumeroSeguroSocial = "-o-";
            output.CodigoPostal = input.CodigoPostal;
            output.TelefonoContacto = input.TelefonoContacto;
            output.DoctoresPacientes = input.DoctoresPacientes.Select(c => DoctorPacienteConvert.toEntity(c)).ToList();
            return output;
        }

        public static PacienteModel toModel(Paciente input)
        {
            PacienteModel output = new PacienteModel();            
            output.Id = input.Id != null ? output.Id = input.Id.ToString() : output.Id = "-o-";
            output.NombreCompleto = input.NombreCompleto != null ? output.NombreCompleto = input.NombreCompleto : input.NombreCompleto = "-o-";
            output.NumeroSeguroSocial = input.NumeroSeguroSocial != null ? output.NumeroSeguroSocial = input.NumeroSeguroSocial : output.NumeroSeguroSocial = "-o-";
            output.CodigoPostal = input.CodigoPostal;
            output.TelefonoContacto = input.TelefonoContacto;
            output.DoctoresPacientes = input.DoctoresPacientes.Select(c => DoctorPacienteConvert.toModel(c)).ToList();
            return output;
        }

        public static List<PacienteModel> toListModel(List<Paciente> input)
        {
            return input.Select(c => toModel(c)).ToList();
        }



    }
}
