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
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorServicio _servicio;        
        private readonly ILogger<DoctorController> _logger;
        private readonly IMapper _mapper;

        public DoctorController(IDoctorServicio servicio,
                                ILogger<DoctorController> logger,
                                IMapper mapper)
        {
            _servicio = servicio;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody]DoctorModel model)
        {
            try
            {
                _logger.LogInformation("Entra al api para crear un doctor");
                var doctorEntity = DoctorConvert.toEntity(model); //_mapper.Map<Doctor>(model);
                var resultado = await _servicio.Crear(doctorEntity);
                return Ok(DoctorConvert.toModel(resultado));  //(_mapper.Map<DoctorModel>(resultado));
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                return BadRequest(e.Message);
            }
            
        }

        [HttpGet("ObtenerPorId")]
        public async Task<IActionResult> ObtenerPorId(string Id)
        {
            try
            {
                _logger.LogInformation("Entra al API para consultar un doctor por Id");
                Guid DoctorId = Guid.Parse(Id);
                var doctor = await _servicio.ObtenerPorId(DoctorId);
                if (doctor == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(DoctorConvert.toModel(doctor));
                }
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                return BadRequest(e.Message);
            }            
        }

        [HttpGet("ObtenerTodos")]
        public async Task<IActionResult> obtenerTodos()
        {
            try
            {
                _logger.LogInformation("Entra al API para consultar todos los doctores");
                var lista = await _servicio.ObtenerTodos();
                if (lista.Count >= 1)
                {
                    var listadoModel = DoctorConvert.toListModel(lista);
                    return Ok(listadoModel);
                }
                else
                {
                    return BadRequest("No hay registros");
                }
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                return BadRequest(e.Message);
            }           
        }

        [HttpPut("Actualizar")]
        public async Task<IActionResult> Actualizar([FromBody]DoctorModel modelo)
        {
            try
            {
                _logger.LogInformation("entra al API para actualizar un doctor");
                var doctorEntity = DoctorConvert.toEntity(modelo);
                var resultado = await _servicio.Actualizar(doctorEntity);
                return Ok(DoctorConvert.toModel(resultado));
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                return BadRequest(e.Message);
            }            
        }

        [HttpDelete("Eliminar")]
        public async Task<IActionResult> Eliminar(string Id)
        {
            try
            {
                _logger.LogInformation("Entra al API para eliminar un doctor");
                Guid DoctorId = Guid.Parse(Id);
                var resultado = await _servicio.Eliminar(DoctorId);
                return Ok(resultado);
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                return BadRequest(e.Message);
            }
           
        }



    }
}