using MongoDB.Bson;

namespace api_doc_mongodb.domain.ModelView
{
    public class GetCustomersModelView
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}