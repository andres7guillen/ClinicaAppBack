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
    public class PacienteRepositorio : IPacienteRepositorio
    {
        private readonly ClinicaContext _context;
        public PacienteRepositorio(ClinicaContext context)
        {
            _context = context;
        }

        public async Task<Paciente> Actualizar(Paciente model)
        {            
            _context.Pacientes.Update(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<Paciente> Crear(Paciente model)
        {
            try
            {
                model.Id = Guid.NewGuid();
                await _context.Pacientes.AddAsync(model);
                await _context.SaveChangesAsync();
                return model;
            }
            catch (Exception e)
            {
                throw e;
            }
           
        }

        public async Task<bool> Eliminar(Guid Id)
        {
            var paciente = await _context.Pacientes.FirstOrDefaultAsync(c => c.Id == Id);
            _context.Pacientes.Remove(paciente);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Paciente> ObtenerPorId(Guid Id)
        {
            return await _context.Pacientes
                .Include(c => c.DoctoresPacientes)
                .FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<List<Paciente>> ObtenerTodos()
        {
            return await _context.Pacientes
                .Include(c => c.DoctoresPacientes)
                .ToListAsync();
        }
    }
}
