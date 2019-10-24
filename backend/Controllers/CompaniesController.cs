using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrainShark.Api.Services.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BrainShark.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly ILogger<CompaniesController> _logger;
        private readonly DatabaseService _databaseService;

        public CompaniesController(ILogger<CompaniesController> logger, DatabaseService databaseService)
        {
            _logger = logger;
            _databaseService = databaseService;
        }


        [HttpGet]
        public IAsyncEnumerable<Company> GetAll([FromQuery] DbSetQuery query) => _databaseService.Companies.Query(query).AsAsyncEnumerable();

        [HttpGet("{id:int}")]
        public Task<Company> Get(int id, [FromQuery] DbSetQuery query) => _databaseService.Companies.Query(query).FirstOrDefaultAsync(x => x.Id == id);

        [HttpGet("{id:int}/Orders")]
        public IAsyncEnumerable<Order> GetOrders(int id, [FromQuery] DbSetQuery query) => _databaseService.Orders.Query(query).Where(x => x.CompanyId == id).AsAsyncEnumerable();
    }
}
