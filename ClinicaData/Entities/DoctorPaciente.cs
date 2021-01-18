using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicaData.Entities
{
    public class DoctorPaciente
    {
        public Guid PacienteId { get; set; }
        public Paciente Paciente { get; set; }
        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
