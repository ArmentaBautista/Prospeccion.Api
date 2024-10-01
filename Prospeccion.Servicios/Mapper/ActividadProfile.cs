using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Prospeccion.Dto.Request;
using Prospeccion.Dto.Responses;
using Prospeccion.Entidades.Negocio;

namespace Prospeccion.Servicios.Mapper
{
    public class ActividadProfile:Profile
    {
        public ActividadProfile()
        {
            CreateMap<EntActividadDtoRequest, EntActividad>();
            CreateMap<EntActividad, EntActividadDtoResponse>();
        }
    }
}
