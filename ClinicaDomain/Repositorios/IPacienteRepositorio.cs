using ClinicaData.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaDomain.Repositorios
{
    public interface IPacienteRepositorio
    {
        Task<Paciente> Crear(Paciente model);
        Task<Paciente> ObtenerPorId(Guid Id);
        Task<List<Paciente>> ObtenerTodos();
        Task<Paciente> Actualizar(Paciente model);
        Task<bool> Eliminar(Guid Id);
    }
}
