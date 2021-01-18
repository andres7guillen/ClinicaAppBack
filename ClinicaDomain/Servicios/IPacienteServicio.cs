using ClinicaData.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaDomain.Servicios
{
    public interface IPacienteServicio
    {
        Task<Paciente> Crear(Paciente model0);
        Task<Paciente> ObtenerPorId(Guid Id);
        Task<List<Paciente>> ObtenerTodos();
        Task<Paciente> Actualizar(Paciente modelo);
        Task<bool> Eliminar(Guid Id);
    }
}
