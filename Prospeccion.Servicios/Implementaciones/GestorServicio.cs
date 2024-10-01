using AutoMapper;
using Prospeccion.Dto.Request;
using Prospeccion.Dto.Responses;
using Prospeccion.Entidades.Negocio;
using Prospeccion.Repositorios.Interfaces;
using Prospeccion.Servicios.Interfaces;
using Prospeccion.Trasversal;

namespace Prospeccion.Servicios.Implementaciones;

public class GestorServicio:IGestorServicio
{
    private IGestorRepository _repositorio;
    private IMapper _mapper;

    public GestorServicio(IGestorRepository repositorio,IMapper mapper)
    {
        _repositorio = repositorio;
        _mapper = mapper;
    }
    public async Task<RespuestaBaseDto<EntGestorDtoResponse>> Registrar(EntGestorDtoRequest gestorDtoRequest)
    {
        RespuestaBaseDto<EntGestorDtoResponse> respuesta = new();
        try
        {
            var resultado = _mapper.Map<EntGestor>(gestorDtoRequest);
            var nuevo = await _repositorio.AddAsync(resultado);
            respuesta.Data = _mapper.Map<EntGestorDtoResponse>(nuevo);
            respuesta.success = true;
            respuesta.message = Constantes.SaveOk;
            return respuesta;
        }
        catch (Exception e)
        {
            throw;
        }
    }

    public async Task<RespuestaPaginacionDto<EntGestorDtoResponse>> Listar(PaginacionDtoRequest paginacionDtoRequest)
    {
        RespuestaPaginacionDto<EntGestorDtoResponse> respuesta = new();
        try
        {
            var resultado = await _repositorio.ListAsync
            (
                predicado: p => p.Estatus == 1,
                selector: p => new EntGestorDtoResponse()
                {
                    usuario = p.Usuario
                },
                orderBy: p => p.Usuario,
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
}