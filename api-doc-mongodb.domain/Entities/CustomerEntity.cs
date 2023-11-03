using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace api_doc_mongodb.domain.Entities
{
    public class CustomerEntity
    {
        [BsonElement("_id")]
        public ObjectId Id { get; set; }
        [BsonElement("name")]
        public string? Name { get; set; }
        [BsonElement("lastName")]
        public string? LastName { get; set; }
        [BsonElement("doc")]
        public string? Doc { get; set; }
        [BsonElement("age")]
        public int Age { get; set; }

        [BsonElement("email")]
        public string? Email { get; set; }
        [BsonElement("birthDate")]
        public BsonDateTime? BirthDate { get; set; }
        public string FormattedBirthDate
        {
            get
            {
                return BirthDate.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");
            }
        }
    }
}