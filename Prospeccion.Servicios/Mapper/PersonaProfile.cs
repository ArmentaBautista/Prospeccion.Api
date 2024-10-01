using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Prospeccion.Dto.Request;
using Prospeccion.Entidades.Negocio;

namespace Prospeccion.Servicios.Mapper
{
    public class PersonaProfile:Profile
    {
        public PersonaProfile()
        {
            CreateMap<EntPersonaDtoRequest, EntPersona>();
            CreateMap<EntPersona, Dto.Responses.EntPersonaDtoResponse>();
        }
    }
}
