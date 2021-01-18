using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicaData.Entities
{
    public class Paciente
    {
        public Guid Id { get; set; }
        public string NombreCompleto { get; set; }
        public string NumeroSeguroSocial { get; set; }
        public string CodigoPostal { get; set; }
        public string TelefonoContacto { get; set; }
        public List<DoctorPaciente> DoctoresPacientes { get; set; }
    }
}
