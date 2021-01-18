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
    public class DoctorRepositorio : IDoctorRepositorio
    {
        private readonly ClinicaContext _context;
        public DoctorRepositorio(ClinicaContext context)
        {
            _context = context;
        }
        public async Task<Doctor> Actualizar(Doctor model)
        {
            _context.Doctores.Update(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<Doctor> Crear(Doctor model)
        {
            model.Id = Guid.NewGuid();
            _context.Doctores.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<bool> Eliminar(Guid Id)
        {
            var Doctor = await _context.Doctores.FirstOrDefaultAsync(c => c.Id == Id);
            _context.Doctores.Remove(Doctor);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Doctor> ObtenerPorId(Guid Id)
        {
            return await _context.Doctores.FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<List<Doctor>> ObtenerTodos()
        {
            return await _context.Doctores.ToListAsync();
        }
    }
}
