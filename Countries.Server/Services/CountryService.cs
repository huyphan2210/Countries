using Countries.Server.Models;
using Countries.Server.Repositories;

namespace Countries.Server.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<IList<Country>> GetCountries()
        {
            return await _countryRepository.GetCountries();
        }

        public async Task<IList<Country>> GetCountriesWithFilter()
        {
            return await _countryRepository.GetCountriesWithFilter();
        }
    }
}
