using Countries.Server.Models;
using Countries.Server.Models.DTOs;

namespace Countries.Server.Repositories
{
    public interface ICountryRepository
    {
        public Task<GetCountriesResponse> GetCountries(GetCountriesRequest getCountriesRequest);
        public Task<Country> GetCountry(string countryName);
    }
}
