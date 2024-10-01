using Prospeccion.Dto.Request;
using Prospeccion.Dto.Responses;

namespace Prospeccion.Servicios.Interfaces;

public interface IGestorServicio
{
    Task<RespuestaBaseDto<EntGestorDtoResponse>> Registrar(EntGestorDtoRequest gestorDtoRequest);
    Task<RespuestaPaginacionDto<EntGestorDtoResponse>> Listar(PaginacionDtoRequest paginacionDtoRequest);
}