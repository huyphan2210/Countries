using Countries.Server.Models.DTOs;
using Countries.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace Countries.Server.Controllers
{
    [ApiController]
    [Route("country")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        private readonly ILogger<CountryController> _logger;

        public CountryController(ICountryService countryService, ILogger<CountryController> logger)
        {
            _countryService = countryService;
            _logger = logger;
        }

        [HttpGet(Name = "GetCountries")]
        public async Task<GetCountriesResponse> GetCountries([FromQuery] GetCountriesRequest getCountriesRequest)
        {
            _logger.LogInformation("Start to get countries");
           return await _countryService.GetCountries(getCountriesRequest);
        }
    }
}
