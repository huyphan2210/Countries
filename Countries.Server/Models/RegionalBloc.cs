using MongoDB.Bson.Serialization.Attributes;

namespace Countries.Server.Models
{
    public class RegionalBloc
    {
        [BsonElement("acronym")]
        public string Acronym { get; set; } = string.Empty;
        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;
        [BsonElement("otherNames")]
        public List<string>? OtherNames { get; set; }
        [BsonElement("otherAcronyms")]
        public List<string>? OtherAcronyms { get; set; }
    }
}
