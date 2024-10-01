using Prospeccion.Dto.Request;
using Prospeccion.Dto.Responses;
using Prospeccion.Servicios.Interfaces;

namespace Prospeccion.Servicios.Implementaciones;

public class GestorServicio:IGestorServicio
{
    public Task<RespuestaBaseDto<EntGestorDtoResponse>> Registrar(EntGestorDtoRequest gestorDtoRequest)
    {
        throw new NotImplementedException();
    }

    public Task<RespuestaPaginacionDto<EntActividadDtoResponse>> Listar(PaginacionDtoRequest paginacionDtoRequest)
    {
        throw new NotImplementedException();
    }
}