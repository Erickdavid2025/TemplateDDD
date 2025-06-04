using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Shared.DTOs
{
    public class ResumenCliente
    {
        public decimal SaldoCuentaPrincipal { get; set; }
        public List<MovimientoResumen> Movimientos { get; set; }
    }

    public class MovimientoResumen
    {
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }
    }
}
