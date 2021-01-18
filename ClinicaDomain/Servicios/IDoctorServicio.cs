﻿using ClinicaData.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaDomain.Servicios
{
    public interface IDoctorServicio
    {
        Task<Doctor> Crear(Doctor model);
        Task<Doctor> ObtenerPorId(Guid Id);
        Task<List<Doctor>> ObtenerTodos();
        Task<Doctor> Actualizar(Doctor model);
        Task<bool> Eliminar(Guid Id);
    }
}
