using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Interfaces;
using Template.Shared.DTOs;

namespace Template.Infraestructure.Repositores
{
    public class ClienteRepository : IClienteRepository
    {
        public Task<ResumenCliente> GetResumenCliente(int id)
        {
            throw new NotImplementedException();
        }
    }
}
