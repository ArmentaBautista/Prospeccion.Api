using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Prospeccion.Dto.Request;
using Prospeccion.Dto.Responses;
using Prospeccion.Entidades.Negocio;

namespace Prospeccion.Servicios.Mapper
{
    public class ResultadoProfile:Profile
    {
        public ResultadoProfile()
        {
            CreateMap<EntResultadoDtoRequest, EntResultadoDtoRequest>();
            CreateMap<EntResultado, EntResultadoDtoResponse>();
        }
    }
}
