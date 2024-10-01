using Galaxy.GestionPedidos.Dto.Request.Usuario;
using Galaxy.GestionPedidos.Dto.Response.Usuario;
using Prospeccion.Dto.Responses;

namespace Prospeccion.Servicios.Interfaces;

public interface IUsuarioServicio
{
    Task<RespuestaBaseDto<UsuarioColaboradorDtoResponse>> ObtenerColaboradorPorUsuario(string usuario);
    Task<RespuestaBaseDto<UsuarioPermisoDtoReponse>> ListarPermisosPorUsuario(string usuario);
    Task<RespuestaBaseDto<LoginDtoResponse>> AutenticarUsuario(LoginDtoRequest request);
}