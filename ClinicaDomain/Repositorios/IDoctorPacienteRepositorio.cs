using ClinicaData.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaDomain.Repositorios
{
    public interface IDoctorPacienteRepositorio
    {
        Task<DoctorPaciente> crearDoctorPaciente(DoctorPaciente modelo);
        Task<List<DoctorPaciente>> obtenerTodos();
    }
}
