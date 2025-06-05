using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Net;

namespace Template.Api.Controllers
{
    [Route("db-health")]
    [ApiController]
    public class DatabaseHealthController : ControllerBase
    {
        private readonly HealthCheckService _healthCheckService;

        public DatabaseHealthController(HealthCheckService healthCheckService)
        {
            _healthCheckService = healthCheckService;
        }

        /// <summary>
        /// Health check 
        /// </summary>
        /// <remarks>
        /// Tests database connection
        /// </remarks>
        /// <returns></returns>
        /// <response code="200">Return database status</response>
        /// <response code="500">In case of internal error</response>
        /// <response code="503">In case database connection fails</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<IActionResult> Get()
        {
            HealthReport report = await _healthCheckService.CheckHealthAsync();

            var result = new
            {
                Status = report.Status.ToString(),
                Entries = report.Entries.Select(e => new { Type = e.Key, Description = e.Value.Description?.ToString() })
            };

            return report.Status == HealthStatus.Healthy ? Ok(result) : StatusCode((int)HttpStatusCode.ServiceUnavailable, result);
        }
    }

}
