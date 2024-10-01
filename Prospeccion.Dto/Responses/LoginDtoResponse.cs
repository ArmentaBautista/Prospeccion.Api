using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy.GestionPedidos.Dto.Response.Usuario
{
    public class LoginDtoResponse
    {
        public string Token { get; set; }
        public string Colaborador { get; set; }
        public string Usuario { get; set; }
        public string Rol { get; set; }
        public DateTime FechaExpiracionToken { get; set; }
    }
}
