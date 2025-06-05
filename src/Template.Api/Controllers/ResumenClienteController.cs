using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Template.Application.Interfaces;
using Template.Shared.DTOs;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Template.Api.Controllers
{
    [Route("api/ResumenCliente")]
    [ApiController]
    public class ResumenClienteController : ControllerBase
    {

        private readonly ICliente _cliente;
        public ResumenClienteController(ICliente cliente)
        {
            _cliente = cliente;
        }

        // GET: api/<ResumenClienteController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
// GET api/<ResumenClienteController>/5

        [HttpGet("/ResumenClienteById/{id}")]
        [ProducesResponseType(typeof(ResumenCliente),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ResumenCliente> Get(int id)
        {
            return await _cliente.GetResumenCliente(id);
        }
        


    }
}
