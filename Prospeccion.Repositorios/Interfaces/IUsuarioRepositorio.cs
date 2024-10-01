using Prospeccion.Entidades.Seguridad;
using Prospeccion.Entidades.Seguridad.Infos;

namespace Prospeccion.Repositorios.Interfaces;

public interface IUsuarioRepositorio
{
    Task<UsuarioColaboradorResult> ObtenerColaboradorPorUsuario(string usuario);
    Task<UsuarioPermisoInfo> ListarPermisosPorUsuario(string usuario);
    Task<UsuarioPermisoInfo> AutenticarUsuario(string usuario, string clave);
}