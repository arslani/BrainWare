using System;
using System.Linq;
using System.Threading.Tasks;
using BrainShark.Api.Services.Info.Abstractions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace BrainShark.Api.Services.Info{
    internal class InfoService : IInfoService {
        private readonly ApplicationInfo _applicationInfo;
        private readonly EnvironmentInfo _environmentInfo;
        private readonly IServiceProvider _services;

        public InfoService(IServiceProvider services, IWebHostEnvironment webHostEnvironment) {
            _applicationInfo = new ApplicationInfo(webHostEnvironment.EnvironmentName);
            _environmentInfo = new EnvironmentInfo();
            _services = services;
        }

        public ApplicationInfo GetApplicationInfo() => _applicationInfo;
        public EnvironmentInfo GetEnvironmentInfo() => _environmentInfo;

        public async Task<Info> GetInfoAsync() {
            var infoServices = _services.GetServices<IInfo>().ToArray();
            var infoTasks = infoServices.Select(async i => (Name: i.GetType().Name, Info: await i.GetInfoAsync()));
            var services = await Task.WhenAll(infoTasks).ContinueWith(t => t.Result.ToDictionary(k => k.Name, v => v.Info));

            return new Info(_applicationInfo, _environmentInfo, services);
        }
    }
}
