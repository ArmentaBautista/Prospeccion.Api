using AutoMapper;
using Prospeccion.Dto.Request;
using Prospeccion.Dto.Responses;
using Prospeccion.Entidades.Negocio;
using Prospeccion.Repositorios.Interfaces;
using Prospeccion.Servicios.Interfaces;
using Prospeccion.Trasversal;

namespace Prospeccion.Servicios.Implementaciones;

public class PersonaServicio:IPersonaServicio
{
    private IPersonaRepository _repositorio;
    private IMapper _mapper;

    public PersonaServicio(IResultadoRepository repositorio, IMapper mapper)
    {
        _repositorio = repositorio;
        _mapper = mapper;
    }

    public async Task<RespuestaBaseDto<EntPersonaDtoResponse>> Registrar(EntPersonaDtoRequest personaDtoRequest)
    {
        RespuestaBaseDto<EntPersonaDtoResponse> respuesta = new();
        try
        {
            var resultado = _mapper.Map<EntPersona>(personaDtoRequest);
            var nuevo = await _repositorio.AddAsync(resultado);
            respuesta.Data = _mapper.Map<EntPersonaDtoResponse>(nuevo);
            respuesta.success = true;
            respuesta.message = Constantes.SaveOk;
            return respuesta;
        }
        catch (Exception e)
        {
            throw;
        }
    }

    public async Task<RespuestaPaginacionDto<EntPersonaDtoResponse>> Listar(PaginacionDtoRequest paginacionDtoRequest)
    {
        RespuestaPaginacionDto<EntPersonaDtoResponse> respuesta = new();
        try
        {
            var resultado = await _repositorio.ListAsync
            (
                predicado: p => p.Estatus == 1,
                selector: p => new EntPersonaDtoResponse()
                {
                    NombreCompleto = p.NombreCompleto,
                    Domicilio = p.Domicilio,
                    Telefono = p.Telefono
                },
                orderBy: p => p.NombreCompleto,
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