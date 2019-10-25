using System.Threading;
using System.Threading.Tasks;

namespace BrainShark.Api.Services.Health
{
    public interface IHealthService
    {
       Task<HealthReport> GetHealthAsync(string tag = default, CancellationToken cancelationToken = default);
    }
}
