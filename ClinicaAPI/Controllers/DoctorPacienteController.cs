using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClinicaAPI.Converts;
using ClinicaAPI.Models;
using ClinicaData.Entities;
using ClinicaDomain.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ClinicaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorPacienteController : ControllerBase
    {
        private readonly IDoctorPacienteServicio _servicio;
        private readonly ILogger<DoctorPacienteController> _logger;
        private readonly IMapper _mapper;

        public DoctorPacienteController(IDoctorPacienteServicio servicio,
        ILogger<DoctorPacienteController> logger,
        IMapper mapper)
        {
            _servicio = servicio;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> crearDoctorPaciente(DoctorPacienteModel model)
        {
            try
            {
                _logger.LogInformation("Entra al API para crear un doctor paciente");
                DoctorPaciente dp = new DoctorPaciente();
                dp = DoctorPacienteConvert.toEntity(model);
                var resultado = await _servicio.crearDoctorPaciente(_mapper.Map<DoctorPaciente>(model));
                return Ok(_mapper.Map<DoctorPacienteModel>(resultado));
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                throw e;
            }            
        }

    }
}