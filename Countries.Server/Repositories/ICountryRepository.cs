using Countries.Server.Models;
using Countries.Server.Models.DTOs;

namespace Countries.Server.Repositories
{
    public interface ICountryRepository
    {
        public Task<IList<GetCountriesResponse>> GetCountries(int page, int pageSize);
        public Task<IList<Country>> GetCountriesWithFilter();
    }
}
