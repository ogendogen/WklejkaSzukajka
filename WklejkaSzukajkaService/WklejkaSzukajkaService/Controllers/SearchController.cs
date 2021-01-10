using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database;
using Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WklejkaSzukajkaService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ILogger<SearchController> _logger;
        private readonly IDatabase _database;

        public SearchController(ILogger<SearchController> logger, IDatabase database)
        {
            _logger = logger;
            _database = database;
        }

        [HttpGet("GetDocsIdsByContains")]
        public async Task<IEnumerable<int>> GetDocsIdsByContains(string condition)
        {
            return await _database.GetDocsIdsByContains(condition);
        }
    }
}
