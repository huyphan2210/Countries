using Countries.Server.Models;
using Countries.Server.Models.DTOs;
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

        public async Task<IList<GetCountriesResponse>> GetCountries(int page, int pageSize)
        {
            return await _countryRepository.GetCountries(page, pageSize);
        }

        public async Task<IList<Country>> GetCountriesWithFilter()
        {
            return await _countryRepository.GetCountriesWithFilter();
        }
    }
}
