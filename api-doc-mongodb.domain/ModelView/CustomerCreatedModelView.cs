using MongoDB.Bson;

namespace api_doc_mongodb.domain.ModelView
{
    public class CustomerCreatedModelView
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
