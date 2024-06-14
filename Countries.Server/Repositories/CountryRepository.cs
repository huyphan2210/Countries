using Countries.Server.Models;
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

        public async Task<IList<Country>> GetCountries()
        {
            try
            {
                var allCountries = await _countries.FindAsync(country => true).ConfigureAwait(false);
                return allCountries.ToList();
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
