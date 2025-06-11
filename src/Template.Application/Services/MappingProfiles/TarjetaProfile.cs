using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.DTOs.Input;
using Template.Application.DTOs.Output;
using Template.Domain.Entities;

namespace Template.Application.Services.MappingProfiles
{
    public class TarjetaProfile : Profile
    {
        public TarjetaProfile()
        {
            CreateMap<NuevaTarjetaInput,Tarjeta>();
            CreateMap<Tarjeta, NuevaTarjetaOutput>().ForMember(dest => dest.numeroTarjeta, opt => opt.MapFrom(src => src.Numero));
        }
    }
}
