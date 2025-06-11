using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.DTOs.Input;
using Template.Application.Interfaces.Repository;
using Template.Infraestructure.ORM_Context;

namespace Template.Infraestructure.Repositores
{
    public class CuentaRepository : ICuentaRepository
    {
        private readonly MyDbContext _myDbContext;
        public CuentaRepository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        public async Task<bool> ExisteCuenta(int id)
        {
            var validateCuenta = await _myDbContext.Cuentas.AnyAsync(x => x.Id == id);
            return validateCuenta;
        }
    }
}
