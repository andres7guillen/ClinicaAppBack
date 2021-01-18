using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicaData.Entities
{
    public class Doctor
    {
        public Guid Id { get; set; }
        public string NombreCompleto { get; set; }
        public string Especialidad { get; set; }
        public string NumeroCredencial { get; set; }
        public string HospitalTrabajo { get; set; }

        public List<DoctorPaciente> DoctoresPacientes { get; set; }
    }
}
