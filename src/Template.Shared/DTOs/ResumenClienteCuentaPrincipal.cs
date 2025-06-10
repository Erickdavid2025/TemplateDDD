using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Shared.DTOs
{
    public class ResumenClienteCuentaPrincipal
    {
        public int cuentaId { get; set; }
        public decimal saldo { get; set; }
        public decimal TotalIngresos { get; set; }
        public decimal TotalEgresos { get; set; }

        public List<MovimientoResult> MovimientosRecientes { get; set; }


    }

    public class MovimientoResult
    {
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
    }
}
