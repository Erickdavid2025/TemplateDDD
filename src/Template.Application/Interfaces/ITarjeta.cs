using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.DTOs.Input;
using Template.Application.DTOs.Output;

namespace Template.Application.Interfaces
{
    public interface ITarjeta
    {
        Task<NuevaTarjetaOutput> AltaTarjeta(NuevaTarjetaInput nuevaTarjetaInput);
    }
}
