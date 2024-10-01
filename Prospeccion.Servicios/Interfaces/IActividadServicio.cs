using Prospeccion.Dto.Request;
using Prospeccion.Dto.Responses;

namespace Prospeccion.Servicios.Interfaces;

public interface IActividadServicio
{
    Task<RespuestaBaseDto<EntActividadDtoResponse>> Registrar(EntActividadDtoRequest actividadDtoRequest);
    Task<RespuestaPaginacionDto<EntActividadDtoResponse>> Listar(PaginacionDtoRequest  paginacionDtoRequest);
}