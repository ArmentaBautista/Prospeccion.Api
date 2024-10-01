using AutoMapper;
using Prospeccion.Dto.Responses;
using Prospeccion.Entidades.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prospeccion.Servicios.Mapper
{
    public class GestorProfile:Profile
    {
        public GestorProfile()
        {
            CreateMap<EntGestorDtoResponse, EntGestor>();
            CreateMap<EntGestor,EntGestorDtoResponse>();
        }
    }
}
