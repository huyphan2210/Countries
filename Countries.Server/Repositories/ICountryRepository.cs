using Countries.Server.Models.DTOs;

namespace Countries.Server.Repositories
{
    public interface ICountryRepository
    {
        public Task<GetCountriesResponse> GetCountries(GetCountriesRequest getCountriesRequest);
    }
}
