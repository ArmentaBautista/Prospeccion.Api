using Microsoft.Extensions.DependencyInjection;
using Prospeccion.Servicios.Implementaciones;
using Prospeccion.Servicios.Interfaces;

namespace Prospeccion.Servicios;

public static class ServiciosExtension
{
    
        public static IServiceCollection AddServicios(this IServiceCollection servicio)
        {
            servicio.AddScoped<IActividadServicio, ActividadServicio>();
            servicio.AddScoped<IGestionServicio, GestionServicio>();
            servicio.AddScoped<IGestorServicio, GestorServicio>();
            servicio.AddScoped<IPersonaServicio, PersonaServicio>();
            servicio.AddScoped<IResultadoServicio, ResultadoServicio>();
            servicio.AddScoped<IUsuarioServicio, UsuarioServicio>();
        return servicio;
        }
    
}