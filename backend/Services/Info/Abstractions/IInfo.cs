using System.Threading.Tasks;

namespace BrainShark.Api.Services.Info.Abstractions{
    public interface IInfo
    {
        Task<object> GetInfoAsync();
    }
}
