namespace Countries.Server.Models.DTOs
{
    public class GetCountriesResponse
    {
        public string Name { get; set; } = string.Empty;
        public string Capital { get; set; } = string.Empty;
        public int Population { get; set; }
        public string Region { get; set; } = string.Empty;
        public string Flag { get; set; } = string.Empty;
    }
}
