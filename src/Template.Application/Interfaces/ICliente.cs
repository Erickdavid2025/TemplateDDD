using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Shared.DTOs;

namespace Template.Application.Interfaces
{
    public interface ICliente
    {
        Task<ResumenCliente> GetResumenCliente(int id);
        Task<ResumenCliente> GetResumenClienteMapper(int id);
    }
}
