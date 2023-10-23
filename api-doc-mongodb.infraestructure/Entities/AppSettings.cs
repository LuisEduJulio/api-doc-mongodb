namespace api_doc_mongodb.infraestructure.Entities
{
    public class AppSettings
    {
        public AppSettings() { }
        public ConnectionStrings ConnectionStrings { get; set; }
    }
    public class ConnectionStrings
    {
        public string Connection { get; set; }
    }
}
