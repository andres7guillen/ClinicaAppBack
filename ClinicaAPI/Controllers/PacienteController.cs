    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicaAPI.Converts;
using ClinicaAPI.Models;
using ClinicaDomain.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ClinicaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteServicio _servicio;
        private readonly ILogger _logger;
        public PacienteController(ILogger<PacienteController>logger, IPacienteServicio servicio)
        {
            _servicio = servicio;
            _logger = logger;
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody]PacienteModel model)
        {
            try
            {
                var PacienteEntity = PacienteConvert.toEntity(model);
                _logger.LogInformation("Se hace un convert de model a entity");
                var resultado = await _servicio.Crear(PacienteEntity);
                return Ok(PacienteConvert.toModel(resultado));
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
                Guid PacienteId = Guid.Parse(Id);
                var Paciente = await _servicio.ObtenerPorId(PacienteId);
                if (Paciente == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(PacienteConvert.toModel(Paciente));
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
                var lista = await _servicio.ObtenerTodos();
                if (lista.Count >= 1)
                {
                    var listadoModel = PacienteConvert.toListModel(lista);
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
        public async Task<IActionResult> Actualizar([FromBody]PacienteModel modelo)
        {
            try
            {
                var PacienteEntity = PacienteConvert.toEntity(modelo);
                var resultado = await _servicio.Actualizar(PacienteEntity);
                return Ok(PacienteConvert.toModel(resultado));
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
                Guid PacienteId = Guid.Parse(Id);
                var resultado = await _servicio.Eliminar(PacienteId);
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