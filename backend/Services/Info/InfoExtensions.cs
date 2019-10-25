using System;
using Microsoft.Extensions.DependencyInjection;

namespace BrainShark.Api.Services.Info {
    public static class InfoExtensions {
        public static IServiceCollection AddInfoService(this IServiceCollection services)
        {

            services.AddSingleton<IInfoService, InfoService>();

            return services;
        }
    }
}
