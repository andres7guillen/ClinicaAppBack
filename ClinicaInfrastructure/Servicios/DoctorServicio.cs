using ClinicaData.Entities;
using ClinicaDomain.Repositorios;
using ClinicaDomain.Servicios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaInfrastructure.Servicios
{
    public class DoctorServicio : IDoctorServicio
    {
        private readonly IDoctorRepositorio _repositorio;
        public DoctorServicio(IDoctorRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        public async Task<Doctor> Actualizar(Doctor modelo) => await _repositorio.Actualizar(modelo);

        public async Task<Doctor> Crear(Doctor modelo) => await _repositorio.Crear(modelo);

        public async Task<bool> Eliminar(Guid Id) => await _repositorio.Eliminar(Id);

        public async Task<Doctor> ObtenerPorId(Guid Id) => await _repositorio.ObtenerPorId(Id);

        public async Task<List<Doctor>> ObtenerTodos() => await _repositorio.ObtenerTodos();

    }
}
