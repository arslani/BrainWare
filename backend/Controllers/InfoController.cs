using System.Threading.Tasks;
using BrainShark.Api.Services.Info;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BrainShark.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfoController : ControllerBase
    {

        private readonly ILogger _logger;
        private readonly IInfoService _info;

        public InfoController(ILogger<InfoController> logger, IInfoService info)
        {
            _logger = logger;
            _info = info;

        }

        [HttpGet]
        public async Task<Info> GetInfoAsync() => await _info.GetInfoAsync();
    }
}
