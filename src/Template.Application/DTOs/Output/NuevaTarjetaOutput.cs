using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Application.DTOs.Output
{
    public class NuevaTarjetaOutput
    {
        public string mensaje { get; } = "Tarjeta registrada correctamente";
        public string numeroTarjeta { get; set; }
        public int cuentaId { get; set; }
        public bool esPrincipal { get; set; }
    }
}
