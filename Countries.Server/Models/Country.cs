using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Countries.Server.Models
{
    public class Country
    {
        [BsonElement("_id")]
        public ObjectId Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;
        [BsonElement("topLevelDomain")]
        public required List<string> TopLevelDomain { get; set; }
        [BsonElement("alpha2Code")]
        public string Alpha2Code { get; set; } = string.Empty;
        [BsonElement("alpha3Code")]
        public string Alpha3Code { get; set; } = string.Empty;
        [BsonElement("callingCodes")]
        public required List<string> CallingCodes { get; set; }
        [BsonElement("capital")]
        public string Capital { get; set; } = string.Empty;
        [BsonElement("altSpellings")]
        public required List<string> AltSpellings { get; set; }
        [BsonElement("subregion")]
        public string SubRegion { get; set; } = string.Empty;
        [BsonElement("region")]
        public string Region { get; set; } = string.Empty;
        [BsonElement("population")]
        public int Population { get; set; }
        [BsonElement("latlng")]
        public required List<double> LatLng { get; set; }
        [BsonElement("demonym")]
        public string Demonym { get; set; } = string.Empty;
        [BsonElement("area")]
        public double Area { get; set; }
        [BsonElement("gini")]
        public double? Gini { get; set; }
        [BsonElement("timezones")]
        public required List<string> Timezones { get; set; }
        [BsonElement("borders")]
        public required List<string> Borders { get; set; }
        [BsonElement("nativeName")]
        public string NativeName { get; set; } = string.Empty;
        [BsonElement("numericCode")]
        public string NumericCode { get; set; } = string.Empty;
        [BsonElement("flags")]
        public required Flag Flags { get; set; }
        [BsonElement("currencies")]
        public required List<Currency> Currencies { get; set; }
        [BsonElement("languages")]
        public required List<Language> Languages { get; set; }
        [BsonElement("translations")]
        public required Translation Translations { get; set; }
        [BsonElement("flag")]
        public string Flag { get; set; } = string.Empty;
        [BsonElement("regionalBlocs")]
        public required List<RegionalBloc> RegionalBlocs { get; set; }
        [BsonElement("cioc")]
        public string Cioc { get; set; } = string.Empty;
        [BsonElement("independent")]
        public bool Independent { get; set; }
    }
}
