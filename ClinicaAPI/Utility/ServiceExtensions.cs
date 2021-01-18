using ClinicaDomain.Repositorios;
using ClinicaDomain.Servicios;
using ClinicaInfrastructure.Repositorios;
using ClinicaInfrastructure.Servicios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaAPI.Utility
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegistroServiciosNegocio(this IServiceCollection services)
        {
            services.AddScoped<IDoctorServicio, DoctorServicio>();
            services.AddScoped<IDoctorRepositorio, DoctorRepositorio>();
            services.AddScoped<IPacienteServicio, PacienteServicio>();
            services.AddScoped<IPacienteRepositorio, PacienteRepositorio>();
            services.AddScoped<IDoctorPacienteServicio, DoctorPacienteServicio>();
            services.AddScoped<IDoctorPacienteRepositorio, DoctorPacienteRepositorio>();

            return services;
        }

    }
}
