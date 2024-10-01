using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy.GestionPedidos.Dto.Request.Usuario
{
    public class LoginDtoRequest
    {
        public string Usuario { get; set; }
        public string Clave { get; set; }
    }
}
