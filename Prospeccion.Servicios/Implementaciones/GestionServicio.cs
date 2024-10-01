using AutoMapper;
using Prospeccion.Dto.Request;
using Prospeccion.Dto.Responses;
using Prospeccion.Entidades.Negocio;
using Prospeccion.Repositorios.Interfaces;
using Prospeccion.Servicios.Interfaces;
using Prospeccion.Trasversal;

namespace Prospeccion.Servicios.Implementaciones;

public class GestionServicio:IGestionServicio
{
    private IGestionRepository _repositorio;
    private IMapper _mapper;

    public GestionServicio(IGestionRepository repositorio, IMapper mapper)
    {
        _repositorio=repositorio;
        _mapper=mapper;
    }
    public async Task<RespuestaBaseDto<EntGestionDtoResponse>> Registrar(EntGestionDtoRequest gestionDtoRequest)
    {
        RespuestaBaseDto<EntGestionDtoResponse> respuesta = new();
        try
        {
            var resultado = _mapper.Map<EntGestion>(gestionDtoRequest);
            var nuevo = await _repositorio.AddAsync(resultado);
            respuesta.Data = _mapper.Map<EntGestionDtoResponse>(nuevo);
            respuesta.success = true;
            respuesta.message = Constantes.SaveOk;
            return respuesta;
        }
        catch (Exception e)
        {
            throw;
        }
    }

    public async Task<RespuestaPaginacionDto<EntGestionDtoResponse>> Listar(PaginacionDtoRequest paginacionDtoRequest)
    {
        RespuestaPaginacionDto<EntGestionDtoResponse> respuesta = new();
        try
        {
            var resultado = await _repositorio.ListAsync
            (
                predicado: p => p.Estatus == 1,
                selector: p => new EntGestionDtoResponse()
                {
                    Actividad = p.IdActividadNavigation.Actividad,
                    Resultado = p.IdResultadoNavigation.Resultado,
                    Persona = p.IdPersonaNavigation.NombreCompleto,
                    Gestor = p.IdGestorNavigation.IdPersonaNavigation.NombreCompleto,
                    Fecha = p.Fecha,
                    Hora = p.Hora,
                    IdActividad = p.IdActividad,
                    IdResultado = p.IdResultado,
                    IdGestor = p.IdGestor,
                    IdPersona = p.IdPersona
                },
                orderBy: p => p.Fecha,
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