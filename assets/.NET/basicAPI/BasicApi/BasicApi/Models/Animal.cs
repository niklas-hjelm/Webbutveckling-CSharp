using MongoDB.Bson.Serialization.Attributes;

namespace BasicApi.Models
{
    public class Animal
    {
        [BsonElement("id")]
        [BsonId]
        public int Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }
    }
}
