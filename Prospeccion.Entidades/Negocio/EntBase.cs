using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prospeccion.Entidades.Negocio
{
    public class EntBase
    {
        [Key]
        public int Id;
        public DateOnly Fecha { get; set; }=DateOnly.FromDateTime(DateTime.Today);
        public TimeOnly Hora { get; set; }=TimeOnly.FromDateTime(DateTime.Today);
        public byte Estatus { get; set; } = 1;

    }
}
