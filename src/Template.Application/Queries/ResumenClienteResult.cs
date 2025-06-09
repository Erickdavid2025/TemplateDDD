using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Application.Queries
{
    public class ResumenClienteResult
    {
        public string Nombre { get; set; }
        public List<CuentaResult> Cuentas { get; set; } = new List<CuentaResult>();
    }

    public class CuentaResult
    {
        public int Cuenta { get; set; }
        public decimal Saldo { get; set; }
        public List<TarjetaResult> Tarjetas { get; set; } = new List<TarjetaResult>();
    }

    public class TarjetaResult
    {
        public string NumeroTarjeta { get; set; }
        public decimal Gastos { get; set; }
        public decimal Ingresos { get; set; }
        public int CantidadMovimientos { get; set; }
    }
}
