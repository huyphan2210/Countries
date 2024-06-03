using Countries.Server.Models;

namespace Countries.Server.Repositories
{
    public interface ICountryRepository
    {
        public Task<IList<Country>> GetCountries();
        public Task<IList<Country>> GetCountriesWithFilter();
    }
}
