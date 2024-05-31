using Countries.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace Countries.Server.Controllers
{
    [ApiController]
    [Route("country")]
    public class CountryController : ControllerBase
    {
        private readonly ILogger<CountryController> _logger;

        public CountryController(ILogger<CountryController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCountries")]
        public IList<Country> GetCountries()
        {
            _logger.LogInformation("Start to get countries");
           return new List<Country>();
        }
    }
}
