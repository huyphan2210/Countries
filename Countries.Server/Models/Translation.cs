using MongoDB.Bson.Serialization.Attributes;

namespace Countries.Server.Models
{
    public class Translation
    {
        [BsonElement("br")]
        public string Br { get; set; } = string.Empty;
        [BsonElement("pt")]
        public string Pt { get; set; } = string.Empty;
        [BsonElement("nl")]
        public string Nl { get; set; } = string.Empty;
        [BsonElement("hr")]
        public string Hr { get; set; } = string.Empty;
        [BsonElement("fa")]
        public string Fa { get; set; } = string.Empty;
        [BsonElement("de")]
        public string De { get; set; } = string.Empty;
        [BsonElement("es")]
        public string Es { get; set; } = string.Empty;
        [BsonElement("fr")]
        public string Fr { get; set; } = string.Empty;
        [BsonElement("ja")]
        public string Ja { get; set; } = string.Empty;
        [BsonElement("it")]
        public string It { get; set; } = string.Empty;
        [BsonElement("hu")]
        public string Hu { get; set; } = string.Empty;
    }
}
