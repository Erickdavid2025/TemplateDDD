using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Application.Queries
{
    public class QueryResumenClienteCuentaPrincipal
    {
        public int cuentaId { get; set; }
        public decimal saldo { get; set; }
        public decimal TotalIngresos { get; set; }
        public decimal TotalEgresos { get; set; }

        public List<QueryMovimientoResult> MovimientosRecientes { get; set; }


    }

    public class QueryMovimientoResult
    {
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
    }


}
