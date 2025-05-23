using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Domain.Entities
{
    public class Tarjeta
    {
        public int Id { get; set; }
        
        public string Numero { get; set; }
        public bool EsPrincipal { get; set; }
        public int CuentaId { get; set; }
        public Cuenta Cuenta { get; set; }
        public ICollection<Movimiento> Movimiento { get; set; }
    }

}
