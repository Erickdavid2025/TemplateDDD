using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Shared.DTOs
{
    public class ResumenCliente
    {
        public string Cliente { get; set; }
        public List<Cuenta> Cuentas { get; set; } = new List<Cuenta>();
    }

    public class Cuenta
    {
        public int id{ get; set; }
        public decimal Saldo { get; set; }
        public List<Tarjeta> Tarjetas { get; set; } = new List<Tarjeta>();
    }

    public class Tarjeta
    {
        public string Numero { get; set; }
        public decimal Gastos { get; set; }
        public decimal Ingresos { get; set; }
        public int CantidadMovimientos { get; set; }
    }
}
