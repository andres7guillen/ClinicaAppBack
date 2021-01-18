using ClinicaData.Context;
using ClinicaData.Entities;
using ClinicaDomain.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaInfrastructure.Repositorios
{
    public class DoctorPacienteRepositorio : IDoctorPacienteRepositorio
    {
        private readonly ClinicaContext _context;
        public DoctorPacienteRepositorio(ClinicaContext context)
        {
            _context = context;
        }

        public async Task<DoctorPaciente> crearDoctorPaciente(DoctorPaciente modelo)
        {
            try
            {
                await _context.DoctoresPacientes.AddAsync(modelo);
                await _context.SaveChangesAsync();
                return modelo;
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        public async Task<List<DoctorPaciente>> obtenerTodos()
        {
            return await _context.DoctoresPacientes.Include(c => c.Doctor).Include(d => d.Paciente).ToListAsync();
        }
    }
}
