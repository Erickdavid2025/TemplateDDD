using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Template.Application.DTOs.Input;
using Template.Application.DTOs.Output;
using Template.Application.Interfaces;

namespace Template.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarjetaController : ControllerBase
    {
        private readonly ITarjeta _tarjeta;
        public TarjetaController(ITarjeta tarjeta)
        {
            _tarjeta = tarjeta;
        }

    /// <summary>
    /// Altas Tarjetas
    /// </summary>
    /// <param name="nuevaTarjetaInput"></param>
    /// <returns></returns>
    [HttpPost("/Alta")]
    [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(NuevaTarjetaOutput))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<NuevaTarjetaOutput> altaTarjeta(NuevaTarjetaInput nuevaTarjetaInput)
    {
         return await _tarjeta.AltaTarjeta(nuevaTarjetaInput);
    }
    }
}
