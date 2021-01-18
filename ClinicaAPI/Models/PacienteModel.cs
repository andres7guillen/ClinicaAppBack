using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaAPI.Models
{
    public class PacienteModel
    {
        public string Id { get; set; }
        public string NombreCompleto { get; set; }
        public string NumeroSeguroSocial { get; set; }
        public string CodigoPostal { get; set; }
        public string TelefonoContacto { get; set; }
        public List<DoctorPacienteModel> DoctoresPacientes { get; set; }
    }
}
