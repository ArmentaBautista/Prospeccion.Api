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
    public class GestorRepository:RepositorioBase<EntGestor>, IGestorRepository
    {
        public GestorRepository(ProspeccionContext context):base(context)
        {   
        }

    }
}
