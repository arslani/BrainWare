using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BrainShark.Api.Services.Info;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace BrainShark.Api.Services.Health
{
    public class HealthService : IHealthService
    {
        private readonly HealthCheckService _healthCheckService;
        private readonly IInfoService _infoService;

        public HealthService(HealthCheckService healthCheckService, IInfoService infoService)
        {
            _healthCheckService = healthCheckService;
            _infoService = infoService;
        }

        public async Task<HealthReport> GetHealthAsync(string tag = default, CancellationToken cancelationToken = default)
        {
            var start = DateTime.UtcNow;
            var report  = await _healthCheckService.CheckHealthAsync(x => x.Tags.Contains(tag), cancelationToken);
            var duration = DateTime.UtcNow.Subtract(start).TotalMilliseconds;

           return new HealthReport(
               application: _infoService.GetApplicationInfo(),
               items: report.Entries.Select(x => new HealthReportItem(x.Key, x.Value.Status == HealthStatus.Healthy, x.Value.Duration.TotalMilliseconds, x.Value.Exception)).ToList(),
               isSuccessful: report.Status == HealthStatus.Healthy,
               duration: duration,
               time: DateTimeOffset.UtcNow
           );
        }
    }
}
