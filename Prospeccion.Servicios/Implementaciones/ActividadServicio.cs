using AutoMapper;
using Prospeccion.Dto.Request;
using Prospeccion.Dto.Responses;
using Prospeccion.Entidades.Negocio;
using Prospeccion.Repositorios.Interfaces;
using Prospeccion.Servicios.Interfaces;
using Prospeccion.Trasversal;

namespace Prospeccion.Servicios.Implementaciones;

public class ActividadServicio : IActividadServicio
{
    private IActividadRepository _repositorio;
    private IMapper _mapper;

    public ActividadServicio(IActividadRepository repositorio,IMapper mapper)
    {
        _repositorio=repositorio;
        _mapper=mapper;
    }
    public async Task<RespuestaPaginacionDto<EntActividadDtoResponse>> Listar(PaginacionDtoRequest paginacionDtoRequest)
    {
        RespuestaPaginacionDto<EntActividadDtoResponse> respuesta = new();
        try
        {
            var resultado = await _repositorio.ListAsync
            (
                predicado:p => p.Estatus==1,
                selector: p => new EntActividadDtoResponse()
                {
                    Id = p.Id,
                    Actividad = p.Actividad
                },
                orderBy: p => p.Actividad,
                pagina: paginacionDtoRequest.NumeroPagina,
                filas: paginacionDtoRequest.TotalFilas
            );

            respuesta.Data = resultado.Collection;
            respuesta.success = true;
            respuesta.TotalFilas = resultado.TotalRegistros;
            respuesta.TotalPagina =
                (int)Math.Ceiling((double)resultado.TotalRegistros / paginacionDtoRequest.TotalFilas);

            return respuesta;
        }
        catch (Exception e)
        {
            throw;
        }
    }

    public async Task<RespuestaBaseDto<EntActividadDtoResponse>> Registrar(EntActividadDtoRequest actividadDtoRequest)
    {
        RespuestaBaseDto<EntActividadDtoResponse> respuesta = new();
        try
        {
            var actividad = _mapper.Map<EntActividad>(actividadDtoRequest);
            var nuevo = await _repositorio.AddAsync(actividad);
            respuesta.Data = _mapper.Map<EntActividadDtoResponse>(nuevo);
            respuesta.success = true;
            respuesta.message = Constantes.SaveOk;
            return respuesta;
        }
        catch (Exception e)
        {
            throw;
        }
    }
}