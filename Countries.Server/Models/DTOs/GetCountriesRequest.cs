namespace Countries.Server.Models.DTOs
{
    public class GetCountriesRequest
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string? SearchString { get; set; }
        public string? Region { get; set; }
    }
}
