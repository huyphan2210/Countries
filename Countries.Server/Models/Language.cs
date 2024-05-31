using System.Text.Json.Serialization;

namespace Countries.Server.Models
{
    public class Language
    {
        [JsonPropertyName("Iso639_1")]
        public string Iso6391 { get; set; } = string.Empty;
        [JsonPropertyName("Iso639_2")]
        public string Iso6392 { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string NativeName { get; set; } = string.Empty;
    }
}
