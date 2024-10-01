using Microsoft.EntityFrameworkCore;
using Prospeccion.AccesoDatos;
using Prospeccion.Dto.Responses;
using Prospeccion.Entidades.Seguridad;
using Prospeccion.Entidades.Seguridad.Infos;
using Prospeccion.Repositorios.Interfaces;

namespace Prospeccion.Repositorios.Implementaciones;

public class UsuarioRepositorio : IUsuarioRepositorio
{
    private SeguridadDbContext _context;

    public UsuarioRepositorio(SeguridadDbContext context)
    {
        _context=context;
    }

    public async Task<UsuarioColaboradorResult> ObtenerColaboradorPorUsuario(string usuario)
    {
        try
        {
            var resultado = await _context.usuarioColaboradorResult
                .FromSqlRaw("select * from ObtenerColaboradoresPorUsuario({0})", usuario)
                .FirstOrDefaultAsync();
            return resultado!;
        }
        catch (Exception)
        {
            throw;
        }
    }


    public async Task<UsuarioPermisoInfo> ListarPermisosPorUsuario(string usuario)
    {
        try
        {
            var resultado = await (from item in _context.Colaboradorusuarios
                                   where item.Usuario!.Equals(usuario)
                                   select new UsuarioPermisoInfo
                                   {
                                       Colaborador = $"{item.IdcolaboradorNavigation.Nombre} {item.IdcolaboradorNavigation.Apellidos}",
                                       Puesto = item.IdcolaboradorNavigation.IdpuestoNavigation.Nombre!,
                                       Usuario = item.Usuario!,
                                       IdUsuario = item.Id,
                                       Permisos = string.Join(",", item.Colaboradorusuariopermisos.Select(p => p.IdpermisoNavigation.Nombre))
                                   })
                             .AsNoTracking()
                             .FirstOrDefaultAsync();

            return resultado!;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<UsuarioPermisoInfo> AutenticarUsuario(string usuario, string clave)
    {
        try
        {
            return await (from item in _context.Colaboradorusuarios
                          where item.Usuario!.Equals(usuario) && item.Clave!.Equals(clave)
                          select new UsuarioPermisoInfo
                          {
                              Colaborador = $"{item.IdcolaboradorNavigation.Nombre} {item.IdcolaboradorNavigation.Apellidos}",
                              Puesto = item.IdcolaboradorNavigation.IdpuestoNavigation.Nombre!,
                              Usuario = item.Usuario!,
                              IdUsuario = item.Id,
                              CorreoElectronico = item.IdcolaboradorNavigation.Correoelectronico!,
                              Permisos = string.Join(",", item.Colaboradorusuariopermisos.Select(p => p.IdpermisoNavigation.Nombre))
                          })
                          .AsNoTracking()
                          .FirstAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

}