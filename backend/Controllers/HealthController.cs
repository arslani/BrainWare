using System.Threading;
using System.Threading.Tasks;
using BrainShark.Api.Services.Health;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace BrainShark.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly IHealthService _healthService;
        public HealthController(IHealthService healthService)
        {
            _healthService = healthService;
        }

        [HttpGet("")]
        public Task<HealthReport> GetAsync(CancellationToken cancelationToken) => GetAsync("ready", cancelationToken);

        [HttpGet("{tag}")]
        public async Task<HealthReport> GetAsync(string tag, CancellationToken cancelationToken)
        {
            var report = await _healthService.GetHealthAsync(tag, cancelationToken);
            Response.StatusCode = report.IsSuccessful ? StatusCodes.Status200OK : StatusCodes.Status503ServiceUnavailable;
            return report;
        }
    }
}
