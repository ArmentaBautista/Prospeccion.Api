using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prospeccion.Entidades.Negocio;
using Prospeccion.Entidades.Negocio.Infos;

namespace Prospeccion.Repositorios.Interfaces
{
    public interface IGestionRepository:IRepositorioBase<EntGestion>
    {
        Task<ICollection<EntGestionInfo>> ListGestionInfoAsync();
    }
}
