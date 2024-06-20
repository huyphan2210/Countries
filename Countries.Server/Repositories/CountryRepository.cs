using Countries.Server.Models;
using Countries.Server.Models.DTOs;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Net;
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

            var proxyUrlString = Environment.GetEnvironmentVariable("QUOTAGUARDSTATIC_URL");
            if (string.IsNullOrEmpty(proxyUrlString))
            {
                throw new InvalidOperationException("QuotaGuard Static URL is not set.");
            }

            var settings = MongoClientSettings.FromConnectionString(connectionString);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            settings.SslSettings = new SslSettings { EnabledSslProtocols = SslProtocols.Tls12 };

            var mongoClient = new MongoClient(settings);
            var database = mongoClient.GetDatabase("country-database");
            _countries = database.GetCollection<Country>("country");
            Task.Run(async () =>
            {
                var publicIp = await GetPublicIpAddressAsync();
                Console.WriteLine("Public IP Address: " + publicIp);
            }).Wait();
        }

        private static async Task<string?> GetPublicIpAddressAsync()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync("https://api.ipify.org");
                    response.EnsureSuccessStatusCode();
                    var ipAddress = await response.Content.ReadAsStringAsync();
                    return ipAddress;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                    return null;
                }
            }
        }

        public async Task<GetCountriesResponse> GetCountries(GetCountriesRequest getCountriesRequest)
        {
            var filter = FilterCountries(getCountriesRequest);

            var option = new FindOptions<Country>
            {
                Skip = (getCountriesRequest.Page - 1) * getCountriesRequest.PageSize,
                Limit = getCountriesRequest.PageSize,
                Sort = Builders<Country>.Sort.Ascending(country => country.Name)
            };

            try
            {
                var countTask = _countries.CountDocumentsAsync(filter);
                var fetchTask = _countries.FindAsync(filter, option);
                await Task.WhenAll(countTask, fetchTask).ConfigureAwait(false);

                var totalDocuments = await countTask;
                var fetchedCountries = await fetchTask;

                var countries = fetchedCountries.ToList().Select(country => new CountryBriefInfo
                {
                    Name = country.Name,
                    Region = country.Region,
                    Capital = country.Capital,
                    Population = country.Population,
                    Flag = country.Flag,
                });

                return new GetCountriesResponse
                {
                    TotalCountries = totalDocuments,
                    Countries = countries.ToList()
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static FilterDefinition<Country> FilterCountries(GetCountriesRequest getCountriesRequest)
        {
            var filterList = new List<FilterDefinition<Country>>();
            if (!string.IsNullOrEmpty(getCountriesRequest.SearchString))
            {
                filterList.Add(Builders<Country>.Filter.Regex(nameof(Country.Name),
                    new BsonRegularExpression(getCountriesRequest.SearchString, "i")));
            }

            if (!string.IsNullOrEmpty(getCountriesRequest.Region))
            {
                filterList.Add(Builders<Country>.Filter.Eq(nameof(Country.Region), getCountriesRequest.Region));
            }

            return filterList.Count > 0
                ? Builders<Country>.Filter.And(filterList)
                : Builders<Country>.Filter.Empty;
        }
    }
}
