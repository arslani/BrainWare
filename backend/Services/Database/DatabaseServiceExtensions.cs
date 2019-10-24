using BrainShark.Api.Services.Info.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BrainShark.Api.Services.Database
{
    public static class DatabaseServiceExtensions
    {
        public static IServiceCollection AddDatabaseService(this IServiceCollection services, string connnectionString)
        {
            services.AddDbContextPool<DatabaseService>(options => options.UseSqlServer(connnectionString));
            services.AddHealthChecks().AddSqlServer(connnectionString, tags: new[] { "ready", "live" });

            services.AddTransient<IInfo, DatabaseService>();

            return services;
        }
    }
}
