using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ClinicaAPI.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly ILogger<BaseController> _logger;

        protected BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;
        }
        protected IActionResult WhenException(Exception e)
        {
            _logger.LogError(e, e.Message);
            ModelState.AddModelError(string.Empty, e.Message);
            if (e.InnerException != null) ModelState.AddModelError(string.Empty, e.InnerException.Message);
            return BadRequest(ModelState);
        }
    }
}