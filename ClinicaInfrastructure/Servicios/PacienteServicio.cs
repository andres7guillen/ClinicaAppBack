using ClinicaData.Entities;
using ClinicaDomain.Repositorios;
using ClinicaDomain.Servicios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaInfrastructure.Servicios
{
    public class PacienteServicio : IPacienteServicio
    {
        private readonly IPacienteRepositorio _repositorio;
        private readonly IDoctorPacienteRepositorio _doctorPacienteRepositorio;
        public PacienteServicio(IPacienteRepositorio repositorio, IDoctorPacienteRepositorio doctorPacienteRepositorio)
        {
            _repositorio = repositorio;
            _doctorPacienteRepositorio = doctorPacienteRepositorio;
        }
        public async Task<Paciente> Actualizar(Paciente modelo) => await _repositorio.Actualizar(modelo);

        public async Task<Paciente> Crear(Paciente modelo)
        {
            foreach (var doctorPaciente in modelo.DoctoresPacientes)
            {
                DoctorPaciente dp = new DoctorPaciente();
                dp.DoctorId = doctorPaciente.DoctorId;
                dp.PacienteId = doctorPaciente.PacienteId;
                await _doctorPacienteRepositorio.crearDoctorPaciente(dp);
            }
            return await _repositorio.Crear(modelo);
        }

        public async Task<bool> Eliminar(Guid Id) => await _repositorio.Eliminar(Id);

        public async Task<Paciente> ObtenerPorId(Guid Id) => await _repositorio.ObtenerPorId(Id);

        public async Task<List<Paciente>> ObtenerTodos() => await _repositorio.ObtenerTodos();
    }
}
