namespace WebApi.Controllers.v1
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Diagnostics.HealthChecks;
    using Newtonsoft.Json.Linq;

    [AllowAnonymous]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        private readonly HealthCheckService _healthCheckService;

        public HealthCheckController(HealthCheckService healthCheckService)
        {
            _healthCheckService = healthCheckService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _healthCheckService.CheckHealthAsync().ConfigureAwait(true);

            var json = new JObject(
                new JProperty("status", result.Status.ToString()),
                new JProperty("execution_time", DateTime.Now.ToString()),
                new JProperty("total_duration", result.TotalDuration.TotalSeconds.ToString() + " seconds"),
                new JProperty("results", new JObject(result.Entries.Select(pair =>
                    new JProperty(pair.Key, new JObject(
                        new JProperty("status", pair.Value.Status.ToString()),
                        new JProperty("description", pair.Value.Description),
                        new JProperty("data", new JObject(pair.Value.Data.Select(
                            p => new JProperty(p.Key, p.Value))))))))));

            return result.Status == HealthStatus.Healthy ? Ok(json) : StatusCode((int)HttpStatusCode.ServiceUnavailable, json);
        }
    }
}