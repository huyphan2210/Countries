using MongoDB.Bson.Serialization.Attributes;

namespace Countries.Server.Models
{
    public class Language
    {
        [BsonElement("iso639_1")]
        public string Iso6391 { get; set; } = string.Empty;
        [BsonElement("iso639_2")]
        public string Iso6392 { get; set; } = string.Empty;
        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;
        [BsonElement("nativeName")]
        public string NativeName { get; set; } = string.Empty;
    }
}
