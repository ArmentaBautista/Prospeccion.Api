using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy.GestionPedidos.Dto.Response.Usuario
{
    public class UsuarioPermisoDtoReponse
    {
        public int IdUsuario { get; set; }
        public string Colaborador { get; set; }
        public string Puesto { get; set; }
        public string Usuario { get; set; }
        public string Permisos { get; set; }
    }
}
