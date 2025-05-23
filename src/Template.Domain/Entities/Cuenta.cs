using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Domain.Entities
{
    public class Cuenta
    {
        public int Id { get; set; }

        public decimal Saldo { get; set; }
        public bool EsCuentaPrincipal { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public ICollection<Tarjeta> Tarjetas { get; set; }
    }

}
