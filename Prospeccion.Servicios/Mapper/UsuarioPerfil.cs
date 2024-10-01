using AutoMapper;
using Galaxy.GestionPedidos.Dto.Response.Usuario;
using Prospeccion.Entidades.Seguridad.Infos;
using Prospeccion.Entidades.Seguridad;

namespace Prospeccion.Servicios.Mapper;

public class UsuarioPerfil : Profile
{
    public UsuarioPerfil()
    {
        CreateMap<UsuarioColaboradorResult, UsuarioColaboradorDtoResponse>();
        CreateMap<UsuarioPermisoInfo, UsuarioPermisoDtoReponse>();
    }
}