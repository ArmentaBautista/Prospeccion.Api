using Prospeccion.Dto.Request;
using Prospeccion.Dto.Responses;

namespace Prospeccion.Servicios.Interfaces;

public interface IGestionServicio
{
    Task<RespuestaBaseDto<EntGestionDtoResponse>> Registrar(EntGestionDtoRequest gestionDtoRequest);
    Task<RespuestaPaginacionDto<EntGestionDtoResponse>> Listar(PaginacionDtoRequest paginacionDtoRequest);
}