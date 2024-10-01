using AutoMapper;
using Prospeccion.Dto.Request;
using Prospeccion.Dto.Responses;
using Prospeccion.Entidades.Negocio;
using Prospeccion.Repositorios.Interfaces;
using Prospeccion.Servicios.Interfaces;
using Prospeccion.Trasversal;

namespace Prospeccion.Servicios.Implementaciones;

public class ResultadoServicio:IResultadoServicio
{
    private IResultadoRepository _repositorio;
    private IMapper _mapper;

    public ResultadoServicio(IResultadoRepository repositorio, IMapper mapper)
    {
        _repositorio = repositorio;
        _mapper = mapper;
    }

    public async Task<RespuestaBaseDto<EntResultadoDtoResponse>> Registrar(EntResultadoDtoRequest resultadodDtoRequest)
    {
        RespuestaBaseDto<EntResultadoDtoResponse> respuesta = new();
        try
        {
            var resultado = _mapper.Map<EntResultado>(resultadodDtoRequest);
            var nuevo = await _repositorio.AddAsync(resultado);
            respuesta.Data = _mapper.Map<EntResultadoDtoResponse>(nuevo);
            respuesta.success = true;
            respuesta.message = Constantes.SaveOk;
            return respuesta;
        }
        catch (Exception e)
        {
            throw;
        }
    }

    public async Task<RespuestaPaginacionDto<EntResultadoDtoResponse>> Listar(PaginacionDtoRequest paginacionDtoRequest)
    {
        RespuestaPaginacionDto<EntResultadoDtoResponse> respuesta = new();
        try
        {
            var resultado = await _repositorio.ListAsync
            (
                predicado: p => p.Estatus == 1,
                selector: p => new EntResultadoDtoResponse()
                {
                    Id = p.Id,
                    Resultado = p.Resultado
                },
                orderBy: p => p.Resultado,
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