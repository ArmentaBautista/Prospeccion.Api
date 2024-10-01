using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prospeccion.Dto.Request;
using Prospeccion.Servicios.Interfaces;

namespace Prospeccion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultadoController : ControllerBase
    {
        private IResultadoServicio _servicio;

        public ResultadoController(IResultadoServicio servicio)
        {
            _servicio=servicio;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginacionDtoRequest request)
        {
            var resultado = await _servicio.Listar(request);
            return resultado.success ? Ok(resultado) : BadRequest(resultado);

        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post(EntResultadoDtoRequest request)
        {
            var resultado = await _servicio.Registrar(request);
            return resultado.success ? Ok(resultado) : BadRequest(resultado);
        }
    }
}
