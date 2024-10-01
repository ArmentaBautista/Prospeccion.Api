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
    public class PersonaRepository:RepositorioBase<EntPersona>,IPersonaRepository
    {
        public PersonaRepository(ProspeccionContext context):base(context)
        {   
        }

        public async Task<ICollection<EntPersonaInfo>> ListMinimalAsynck()
        {
            var personas = DbContext.Set<EntPersona>()
                .Where(p => p.Estatus == 1)
                .Select(x => new EntPersonaInfo()
                {
                    Id = x.Id,
                    NombreCompleto = x.NombreCompleto,
                    Domicilio = x.Domicilio,
                    Telefono = x.Telefono
                })
                .AsNoTracking()
                .AsQueryable();

            return await personas.ToListAsync();
        }
    }
}
