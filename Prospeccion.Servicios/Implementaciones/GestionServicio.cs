using Prospeccion.Dto.Request;
using Prospeccion.Dto.Responses;
using Prospeccion.Servicios.Interfaces;

namespace Prospeccion.Servicios.Implementaciones;

public class GestionServicio:IGestionServicio
{
    public Task<RespuestaBaseDto<EntGestionDtoResponse>> Registrar(EntGestionDtoRequest gestionDtoRequest)
    {
        throw new NotImplementedException();
    }

    public Task<RespuestaPaginacionDto<EntGestionDtoResponse>> Listar(PaginacionDtoRequest paginacionDtoRequest)
    {
        throw new NotImplementedException();
    }
}