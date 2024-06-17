using Countries.Server.Models;
using Countries.Server.Models.DTOs;
using MongoDB.Driver;
using System.Security.Authentication;

namespace Countries.Server.Repositories
{

    public class CountryRepository : ICountryRepository
    {
        private readonly IMongoCollection<Country> _countries;

        public CountryRepository(IConfiguration configuration)
        {
            var connectionStringTemplate = configuration.GetConnectionString("MongoDB") ?? "";
            var connectionPassword = Environment.GetEnvironmentVariable("MONGODB_PASSWORD") ?? "";
            var connectionString = connectionStringTemplate.Replace("{password}", connectionPassword);
            var settings = MongoClientSettings.FromConnectionString(connectionString);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };

            var client = new MongoClient(settings);
            var database = client.GetDatabase("country-database");
            _countries = database.GetCollection<Country>("country");
        }

        public async Task<IList<GetCountriesResponse>> GetCountries(int page, int pageSize)
        {
            var option = new FindOptions<Country>
            {
                Skip = (page - 1) * pageSize,
                Limit = pageSize
            };

            try
            {
                var allCountries = await _countries.FindAsync(country => true, option).ConfigureAwait(false);
                var countries = allCountries.ToList().Select(country => new GetCountriesResponse
                {
                    Name = country.Name,
                    Region = country.Region,
                    Capital = country.Capital,
                    Population = country.Population,
                    Flag = country.Flag,
                });
                return countries.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IList<Country>> GetCountriesWithFilter()
        {
            return new List<Country>();
        }
    }
}
