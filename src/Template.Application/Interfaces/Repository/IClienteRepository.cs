using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.Queries;
using Template.Shared.DTOs;

namespace Template.Application.Interfaces.Repository
{
    public interface IClienteRepository
    {
       Task<ResumenCliente> GetResumenCliente(int id);

       Task<ResumenClienteResult> GetResumenClienteMapper(int id);

       Task<QueryResumenClienteCuentaPrincipal> GetResumenClienteCuentaPrincipal(int id);
    }
}
