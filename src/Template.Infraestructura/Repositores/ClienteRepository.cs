using Microsoft.EntityFrameworkCore;
using Template.Application.Interfaces.Repository;
using Template.Application.Queries;
using Template.Infraestructure.ORM_Context;
using Template.Shared.DTOs;
using Cuenta = Template.Shared.DTOs.Cuenta;
using Tarjeta = Template.Shared.DTOs.Tarjeta;

namespace Template.Infraestructure.Repositores
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly MyDbContext _myDbContext;
        public ClienteRepository(MyDbContext myDbContext)
        {
           _myDbContext = myDbContext;
        }
        public async Task<ResumenCliente> GetResumenCliente(int id)
        {

            var todoJunto = await (from n in _myDbContext.Clientes
                             where n.Id == id
                             select new {
                             nombre = n.Nombre,
                             cuentas = (from a in _myDbContext.Cuentas
                                       where n.Id == a.ClienteId
                                       select new
                                       {
                                           cuenta = a.Id,
                                           saldo = a.Saldo,
                                           tarjetas = (from tar in _myDbContext.Tarjetas
                                                       join mov in _myDbContext.Movimientos on tar.Id equals mov.TarjetaId
                                                       where tar.CuentaId == a.Id
                                                       group mov by tar.Numero into grupo
                                                       select new
                                                       {
                                                           numeroTarjeta = grupo.Key,
                                                           gastos = grupo.Sum( m=> m.Monto < 0 ? m.Monto : 0),
                                                           ingresos = grupo.Sum( m=> m.Monto > 0 ? m.Monto : 0),
                                                           CantidadMovimientos= grupo.Count()
                                                       }).ToList()
                                       }).ToList()
                             
                             }).FirstOrDefaultAsync();



            ResumenCliente resumen = new ResumenCliente();
            resumen.Cliente = todoJunto.nombre;
            foreach (var data in todoJunto.cuentas)
            {
                var cuenta = new Cuenta
                {
                    id = data.cuenta,
                    Saldo = data.saldo,
                    Tarjetas = new List<Tarjeta>()

                };
                
                foreach (var dataTarjeta in data.tarjetas)
                {
                    var tarjeta = new Tarjeta
                    {
                        Numero =  dataTarjeta.numeroTarjeta,
                        Gastos = dataTarjeta.gastos,
                        Ingresos = dataTarjeta.ingresos,
                        CantidadMovimientos = dataTarjeta.CantidadMovimientos
                    };
                    cuenta.Tarjetas.Add(tarjeta);
                }
                resumen.Cuentas.Add(cuenta);
            }

            return resumen ;
        }

        public async Task<ResumenClienteResult> GetResumenClienteMapper(int id)
        {
            var todoJunto = await (from n in _myDbContext.Clientes
                                  where n.Id == id
                                  select new ResumenClienteResult
                                  {
                                      Nombre = n.Nombre,
                                      Cuentas = (from a in _myDbContext.Cuentas
                                                 where n.Id == a.ClienteId
                                                 select new CuentaResult
                                                 {
                                                     Cuenta = a.Id,
                                                     Saldo = a.Saldo,
                                                     Tarjetas = (from tar in _myDbContext.Tarjetas
                                                                 join mov in _myDbContext.Movimientos on tar.Id equals mov.TarjetaId
                                                                 where tar.CuentaId == a.Id
                                                                 group mov by tar.Numero into grupo
                                                                 select new TarjetaResult
                                                                 {
                                                                     NumeroTarjeta = grupo.Key,
                                                                     Gastos = grupo.Sum(m => m.Monto < 0 ? m.Monto : 0),
                                                                     Ingresos = grupo.Sum(m => m.Monto > 0 ? m.Monto : 0),
                                                                     CantidadMovimientos = grupo.Count()
                                                                 }).ToList()
                                                 }).ToList()

                                  }).FirstOrDefaultAsync();


            return todoJunto;


        }

    }
}
