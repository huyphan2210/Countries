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
        public required List<string> AltSpellings { get; set; }
        public string SubRegion { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public int Population { get; set; }
        public required List<int> LatLng { get; set; }
        public string Demonym { get; set; } = string.Empty;
        public int Area { get; set; }
        public required List<string> Timezones { get; set; }
        public required List<string> Borders { get; set; }
        public string NativeName { get; set; } = string.Empty;
        public string NumericCode { get; set; } = string.Empty;
        public required List<Flag> Flags { get; set; }
        public required List<Currency> Currencies { get; set; }
        public required List<Language> Languages { get; set; }
        public required List<Translation> Translations { get; set; }
        public string Flag { get; set; } = string.Empty;
        public required List<RegionalBloc> RegionalBlocs { get; set; }
        public string Cioc { get; set; } = string.Empty;
        public bool Independent { get; set; }
    }
}
