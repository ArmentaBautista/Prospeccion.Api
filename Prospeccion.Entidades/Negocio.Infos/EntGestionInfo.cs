using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prospeccion.Entidades.Negocio.Infos
{
    public class EntGestionInfo
    {
        public int Id { get; set; }
        public string Gestor { get; set; } = string.Empty;
        public string Persona { get; set; } = string.Empty;
        public string Actividad { get; set; } = string.Empty;
        public string Resultado { get; set; } = string.Empty;
        public DateOnly Fecha { get; set; }
        public TimeOnly Hora { get; set; }
    }
}
