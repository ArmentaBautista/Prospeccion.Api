using Galaxy.GestionPedidos.Dto.Request.Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prospeccion.Servicios.Interfaces;

namespace Prospeccion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguridadController : ControllerBase
    {
        private IUsuarioServicio _servicio;
        public SeguridadController(IUsuarioServicio servicio)
        {
            _servicio = servicio;
        }

        [Authorize]
        [HttpGet("Usuario/ByUsername/{username}")]
        public async Task<IActionResult> Get(string username)
        {
            var resultado = await _servicio.ObtenerColaboradorPorUsuario(username);
            return resultado.success ? Ok(resultado) : BadRequest(resultado);
        }

        [Authorize]
        [HttpGet("Permisos/ByUsername/{username}")]
        public async Task<IActionResult> GetPermisos(string username)
        {
            var resultado = await _servicio.ListarPermisosPorUsuario(username);
            return resultado.success ? Ok(resultado) : BadRequest(resultado);
        }

        [HttpPost("Autenticacion/Login")]
        public async Task<IActionResult> Login(LoginDtoRequest request)
        {
            var resultado = await _servicio.AutenticarUsuario(request);
            return resultado.success ? Ok(resultado) : BadRequest(resultado);
        }
    }
}
