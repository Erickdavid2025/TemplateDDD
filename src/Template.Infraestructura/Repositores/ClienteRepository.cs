using Template.Domain.Entities;
using Template.Domain.Interfaces;
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
            myDbContext = _myDbContext;
        }
        public async Task<ResumenCliente> GetResumenCliente(int id)
        {

            var todoJunto = (from n in _myDbContext.Clientes
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
                             
                             }).FirstOrDefault();



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
    }
}
