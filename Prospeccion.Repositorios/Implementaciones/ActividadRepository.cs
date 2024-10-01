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
    public class ActividadRepository:RepositorioBase<EntActividad>,IActividadRepository
    {
        private ProspeccionContext _context;
        public ActividadRepository(ProspeccionContext context)
            : base(context)
        {
            _context=context;
        }

    }
}
