using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prospeccion.Dto.Responses
{
    public class RespuestaBaseDto
    {
        public string? message { get; set; }
        public bool success { get; set; }
    }

    public class RespuestaBaseDto<T> : RespuestaBaseDto
    {
        public T? Data { get; set; }
    }
}
