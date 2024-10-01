using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prospeccion.AccesoDatos;
using Prospeccion.Entidades.Negocio;
using Prospeccion.Repositorios.Interfaces;

namespace Prospeccion.Repositorios.Implementaciones
{
    public class ResultadoRepository:RepositorioBase<EntResultado>,IResultadoRepository
    {
        private ProspeccionContext _context;
        public ResultadoRepository(ProspeccionContext context):base(context)
        {
            _context = context;
        }
    }
}
