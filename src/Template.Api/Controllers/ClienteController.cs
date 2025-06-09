using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Template.Application.Interfaces;
using Template.Shared.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Template.Api.Controllers
{
    [Route("api/Desafio3/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly ICliente _cliente;
        public ClienteController(ICliente cliente)
        {
            _cliente = cliente;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}/resumen-financiero")]
        [ProducesResponseType(StatusCodes.Status200OK,Type=typeof(ResumenCliente))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        ///<summary>Obtenemos el resumen detallado del cliente</summary>
        ///<responsy code="200">Retorna todo el detalle</responsy>
        public async Task<ResumenCliente> Get(int id)
        {
            return await _cliente.GetResumenCliente(id);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}/resumen-financiero/Mapper")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResumenCliente))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        ///<summary>Obtenemos el resumen detallado del cliente</summary>
        ///<responsy code="200">Retorna todo el detalle</responsy>
        public async Task<ResumenCliente> GetMapper(int id)
        {
            return await _cliente.GetResumenClienteMapper(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
