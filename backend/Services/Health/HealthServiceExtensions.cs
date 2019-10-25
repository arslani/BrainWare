using Microsoft.Extensions.DependencyInjection;

namespace BrainShark.Api.Services.Health
{
    public static class HealthServiceExtensions
    {
        public static IServiceCollection AddHealthService(this IServiceCollection services)
        {
            services.AddHealthChecks();
            services.AddSingleton<IHealthService, HealthService>();

            return services;
        }
    }
}
