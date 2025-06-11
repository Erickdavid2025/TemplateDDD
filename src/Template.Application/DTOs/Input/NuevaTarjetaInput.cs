using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Application.DTOs.Input
{
    public class NuevaTarjetaInput
    {
        public int CuentaId { get; set; }
        public string Numero { get; set; }
        public bool EsPrincipal { get; set; }
    }
}
