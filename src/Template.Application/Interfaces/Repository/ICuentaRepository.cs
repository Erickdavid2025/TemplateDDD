using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Application.Interfaces.Repository
{
    public interface ICuentaRepository
    {
        Task<bool> ExisteCuenta(int id);
    }
}
