using AutoMapper;
using Prospeccion.Servicios.Mapper;

namespace Prospeccion.Servicios;

public static class PerfilesMapperExtension
{
    public static IMapperConfigurationExpression AddPerfilesMapper(this IMapperConfigurationExpression config)
    {
        config.AddProfile<ActividadProfile>();
        config.AddProfile<GestionProfile>();
        config.AddProfile<GestorProfile>();
        config.AddProfile<PersonaProfile>();
        config.AddProfile<ResultadoProfile>();
        return config;
    }
}