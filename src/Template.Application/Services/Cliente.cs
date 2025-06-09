using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.Interfaces;
using Template.Application.Interfaces.Repository;
using Template.Domain.Entities;
using Template.Shared.DTOs;

namespace Template.Application.Services

{
    public class Cliente : ICliente
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public Cliente(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }
        public async Task<ResumenCliente>  GetResumenCliente(int id)
        {
            try {
                return await _clienteRepository.GetResumenCliente(id);
            } 
            catch (Exception x)
            {
                throw x;
            }
        }

        public async Task<ResumenCliente> GetResumenClienteMapper(int id)
        {
            try
            {
                var resultadoQuery =  await _clienteRepository.GetResumenCliente(id);
                var resumen = _mapper.Map<ResumenCliente>(resultadoQuery);
                return resumen;
            }
            catch (Exception x)
            {
                throw x;
            }
        }
    }
}
