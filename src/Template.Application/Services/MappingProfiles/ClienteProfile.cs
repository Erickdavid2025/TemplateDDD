using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.Queries;
using Template.Shared.DTOs;

namespace Template.Application.Services.Mapper
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<ResumenClienteResult, ResumenCliente>()
                .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.Nombre));
            CreateMap<CuentaResult, Cuenta>();
            CreateMap<TarjetaResult, Tarjeta>();


            ////////DESAFIO 4
            CreateMap<QueryResumenClienteCuentaPrincipal, ResumenClienteCuentaPrincipal>();
            CreateMap<QueryMovimientoResult, MovimientoResult>();
        }
    }
}
