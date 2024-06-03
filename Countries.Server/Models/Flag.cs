using MongoDB.Bson.Serialization.Attributes;

namespace Countries.Server.Models
{
    public class Flag
    {
        [BsonElement("svg")]
        public string Svg { get; set; } = string.Empty;
        [BsonElement("png")]
        public string Png { get; set; } = string.Empty;
    }
}
