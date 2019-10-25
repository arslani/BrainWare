using System.Threading.Tasks;

namespace BrainShark.Api.Services.Info
{
    public interface IInfoService {

        ApplicationInfo GetApplicationInfo();
        EnvironmentInfo GetEnvironmentInfo();
        Task<Info> GetInfoAsync();
    }
}
