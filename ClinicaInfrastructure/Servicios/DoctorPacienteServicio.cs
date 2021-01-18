using ClinicaData.Entities;
using ClinicaDomain.Servicios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaInfrastructure.Servicios
{
    public class DoctorPacienteServicio : IDoctorPacienteServicio
    {
        private readonly IDoctorPacienteServicio _repositorio;
        public DoctorPacienteServicio(IDoctorPacienteServicio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<DoctorPaciente> crearDoctorPaciente(DoctorPaciente modelo) => await _repositorio.crearDoctorPaciente(modelo);

        public async Task<List<DoctorPaciente>> obtenerTodos() => await _repositorio.obtenerTodos();
    }
}
