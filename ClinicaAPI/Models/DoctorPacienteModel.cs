using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaAPI.Models
{
    public class DoctorPacienteModel
    {
        public string PacienteId { get; set; }
        public PacienteModel Paciente { get; set; }
        public string DoctorId { get; set; }
        public DoctorModel Doctor { get; set; }
    }
}
