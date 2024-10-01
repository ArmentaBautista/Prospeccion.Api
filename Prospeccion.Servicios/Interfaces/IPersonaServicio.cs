using Prospeccion.Dto.Request;
using Prospeccion.Dto.Responses;

namespace Prospeccion.Servicios.Interfaces;

public interface IPersonaServicio
{
    Task<RespuestaBaseDto<EntPersonaDtoResponse>> Registrar(EntPersonaDtoRequest personaDtoRequest);
    Task<RespuestaPaginacionDto<EntPersonaDtoResponse>> Listar(PaginacionDtoRequest paginacionDtoRequest);
}