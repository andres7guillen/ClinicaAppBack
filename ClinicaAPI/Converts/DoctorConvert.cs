using ClinicaAPI.Models;
using ClinicaData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaAPI.Converts
{
    public static class DoctorConvert
    {
        public static Doctor toEntity(DoctorModel input)
        {
            Doctor output = new Doctor();
            output.Id = input.Id != null ? output.Id = Guid.Parse(input.Id) : output.Id = Guid.Empty;
            output.NombreCompleto = input.NombreCompleto != null ? output.NombreCompleto = input.NombreCompleto: output.NombreCompleto = "";
            output.Especialidad = input.Especialidad;
            output.NumeroCredencial = input.NumeroCredencial;
            output.HospitalTrabajo = input.HospitalTrabajo;
            return output;
        }

        public static DoctorModel toModel(Doctor input)
        {
            DoctorModel output = new DoctorModel();
            output.Id = input.Id != null ? output.Id = input.Id.ToString() : output.Id = "-o-";
            output.NombreCompleto = input.NombreCompleto != null ? output.NombreCompleto = input.NombreCompleto : output.Id = "-o-";
            output.Especialidad = input.Especialidad;
            output.NumeroCredencial = input.NumeroCredencial;
            output.HospitalTrabajo = input.HospitalTrabajo;
            return output;
        }

        public static List<DoctorModel> toListModel(List<Doctor> input)
        {
            return input.Select(c => toModel(c)).ToList();
        }

    }
}
