using MongoDB.Bson.Serialization.Attributes;

namespace Countries.Server.Models
{
    public class Currency
    {
        [BsonElement("code")]
        public string Code { get; set; } = string.Empty;
        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;
        [BsonElement("symbol")]
        public string Symbol { get; set; } = string.Empty;
    }
}
