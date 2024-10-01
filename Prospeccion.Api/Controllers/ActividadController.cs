﻿using Microsoft.AspNetCore.Mvc;
using Prospeccion.Dto.Request;
using Prospeccion.Servicios.Interfaces;

namespace Prospeccion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadController : ControllerBase
    {
        private IActividadServicio _servicio;

        public ActividadController(IActividadServicio servicio)
        {
            _servicio=servicio;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginacionDtoRequest request)
        {
            var resultado = await _servicio.Listar(request);
            return resultado.success ? Ok(resultado) : BadRequest(resultado);

        }

        [HttpPost]
        public async Task<IActionResult> Post(EntActividadDtoRequest request)
        {
            var resultado = await _servicio.Registrar(request);
            return resultado.success ? Ok(resultado) : BadRequest(resultado);
        }

    }
}
