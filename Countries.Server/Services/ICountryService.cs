using Countries.Server.Models;

namespace Countries.Server.Services
{
    public interface ICountryService
    {
        public Task<IList<Country>> GetCountries();
        public Task<IList<Country>> GetCountriesWithFilter();
    }
}
