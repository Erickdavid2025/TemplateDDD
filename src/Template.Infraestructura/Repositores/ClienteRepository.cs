using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities;
using Template.Domain.Interfaces;
using Template.Infraestructura.ORM;
using Template.Shared.DTOs;

namespace Template.Infraestructure.Repositores
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly MyDbContext _IMyDbContext;
        public ClienteRepository(MyDbContext myDbContext)
        {
            _IMyDbContext = myDbContext;
        }
        public async Task<ResumenCliente> GetResumenCliente(int id)
        {
            try
            {

                 var saldo = await _IMyDbContext.Cuentas
                .Where(x => x.ClienteId == id && x.EsCuentaPrincipal)
                .Select(x => (decimal?)x.Saldo)
                .FirstOrDefaultAsync() ?? 0m;



                var movimientos =  await (from movimiento in _IMyDbContext.Movimientos
                                         join tarjeta in _IMyDbContext.Tarjetas on movimiento.TarjetaId equals tarjeta.Id
                                         join cuenta in _IMyDbContext.Cuentas on tarjeta.CuentaId equals cuenta.Id
                                         where cuenta.ClienteId == id
                                         orderby movimiento.Fecha descending
                                         select new MovimientoResumen
                                         {
                                             Fecha = movimiento.Fecha,
                                             Monto = movimiento.Monto,
                                             Descripcion = movimiento.Descripcion
                                         })
                                  .Take(5)
                                  .ToListAsync()
                                  ;


                return new ResumenCliente
                {
                    SaldoCuentaPrincipal = saldo,
                    Movimientos = movimientos
                };
            }catch(Exception x)
            {
                throw x;
            }
           
        }
    }
}
