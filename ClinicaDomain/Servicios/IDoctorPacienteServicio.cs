using ClinicaData.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaDomain.Servicios
{
    public interface IDoctorPacienteServicio
    {
        Task<DoctorPaciente> crearDoctorPaciente(DoctorPaciente modelo);
        Task<List<DoctorPaciente>> obtenerTodos();
    }
}
