using Countries.Server.Models;
using Countries.Server.Models.DTOs;

namespace Countries.Server.Services
{
    public interface ICountryService
    {
        public Task<GetCountriesResponse> GetCountries(GetCountriesRequest getCountriesRequest);
        public Task<Country> GetCountry(string countryName);
    }
}
