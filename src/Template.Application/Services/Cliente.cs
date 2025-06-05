using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.Interfaces;
using Template.Domain.Interfaces;
using Template.Infraestructura.ORM;
using Template.Shared.DTOs;

namespace Template.Application.Services

{
    public class Cliente : ICliente
    {
        private readonly IClienteRepository _clienteRepository;

        public Cliente(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
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
    }
}
