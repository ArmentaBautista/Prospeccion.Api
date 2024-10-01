using Prospeccion.Dto.Request;
using Prospeccion.Dto.Responses;

namespace Prospeccion.Servicios.Interfaces;

public interface IResultadoServicio
{
    Task<RespuestaBaseDto<EntResultadoDtoResponse>> Registrar(EntResultadoDtoRequest resultadodDtoRequest);
    Task<RespuestaPaginacionDto<EntResultadoDtoResponse>> Listar(PaginacionDtoRequest paginacionDtoRequest);
}