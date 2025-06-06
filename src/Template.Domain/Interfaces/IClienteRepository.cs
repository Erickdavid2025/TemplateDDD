using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Shared.DTOs;

namespace Template.Domain.Interfaces
{
    public interface IClienteRepository
    {
       Task<ResumenCliente> GetResumenCliente(int id);
    }
}
