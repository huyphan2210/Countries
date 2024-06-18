namespace Countries.Server.Models.DTOs
{
    public class GetCountriesResponse
    {
        public long TotalCountries { get; set; }
        public List<CountryBriefInfo> Countries { get; set; } = new();
    }

    public class CountryBriefInfo
    {
        public string Name { get; set; } = string.Empty;
        public string Capital { get; set; } = string.Empty;
        public int Population { get; set; }
        public string Region { get; set; } = string.Empty;
        public string Flag { get; set; } = string.Empty;
    }
}
