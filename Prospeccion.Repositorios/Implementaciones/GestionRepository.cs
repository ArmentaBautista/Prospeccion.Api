using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Prospeccion.AccesoDatos;
using Prospeccion.Entidades.Negocio;
using Prospeccion.Entidades.Negocio.Infos;
using Prospeccion.Repositorios.Interfaces;

namespace Prospeccion.Repositorios.Implementaciones
{
    public class GestionRepository:RepositorioBase<EntGestion>, IGestionRepository
    {
        public GestionRepository(ProspeccionContext context):base(context)
        {
        }

        public async Task<ICollection<EntGestionInfo>> ListGestionInfoAsync()
        {
            var gestiones = DbContext.Set<EntGestion>()
                .Where(p => p.Estatus == 1)
                .Select(x => new EntGestionInfo
                {
                    Id = x.Id,
                    Gestor = x.IdGestorNavigation.IdPersonaNavigation.NombreCompleto,
                    Persona = x.IdPersonaNavigation.NombreCompleto,
                    Actividad = x.IdActividadNavigation.Actividad,
                    Resultado = x.IdResultadoNavigation.Resultado,
                    Fecha = x.Fecha,
                    Hora = x.Hora
                })
                .AsNoTracking()
                .AsQueryable();

            return await gestiones.ToListAsync();
        }


    }
}
