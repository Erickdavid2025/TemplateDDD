using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Domain.Entities
{
    public class Movimiento
    {
        public int Id { get; set; }
        
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }

        public int TarjetaId { get; set; }
        public Tarjeta Tarjeta { get; set; }


    }

}
