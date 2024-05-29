namespace Countries.Server.Models
{
    public class Country
    {
        public string Name { get; set; } = string.Empty;
        public required List<string> TopLevelDomain { get; set; }
        public string Alpha2Code { get; set; } = string.Empty;
        public string Alpha3Code { get; set; } = string.Empty;
        public required List<string> CallingCodes { get; set; }
        public string Capital { get; set; } = string.Empty;
        public required List<string> AltSpellings { get; set; };
        //public
    }
}
