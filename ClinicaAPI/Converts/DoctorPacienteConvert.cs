using ClinicaAPI.Models;
using ClinicaData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaAPI.Converts
{
    public static class DoctorPacienteConvert
    {
        public static DoctorPaciente toEntity(DoctorPacienteModel input)
        {
            DoctorPaciente output = new DoctorPaciente();
            //output.Doctor = DoctorConvert.toEntity(input.Doctor);
            output.DoctorId = input.DoctorId != null ? output.DoctorId = Guid.Parse(input.DoctorId) : Guid.Empty;
            //output.Paciente = PacienteConvert.toEntity(input.Paciente);
            output.PacienteId = input.PacienteId != null ? output.PacienteId = Guid.Parse(input.PacienteId) : Guid.Empty;
            return output;
        }

        public static DoctorPacienteModel toModel(DoctorPaciente input)
        {
            DoctorPacienteModel output = new DoctorPacienteModel();
            output.Doctor = DoctorConvert.toModel(input.Doctor);
            output.DoctorId = input.DoctorId.ToString();
            output.Paciente = PacienteConvert.toModel(input.Paciente);
            output.PacienteId = input.PacienteId.ToString();

            return output;
        }
    }
}
