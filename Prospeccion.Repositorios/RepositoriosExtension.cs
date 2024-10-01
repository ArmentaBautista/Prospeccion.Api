using Microsoft.Extensions.DependencyInjection;
using Prospeccion.Repositorios.Implementaciones;
using Prospeccion.Repositorios.Interfaces;

namespace Prospeccion.Repositorios;

public static class RepositoriosExtension
{
    public static IServiceCollection AddRepositorios(this IServiceCollection servicio)
    {
        servicio.AddScoped<IActividadRepository, ActividadRepository>();
        servicio.AddScoped<IGestionRepository, GestionRepository>();
        servicio.AddScoped<IGestorRepository, GestorRepository>();
        servicio.AddScoped<IPersonaRepository, PersonaRepository>();
        servicio.AddScoped<IResultadoRepository, ResultadoRepository>();
        servicio.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
        return servicio;
    }
}