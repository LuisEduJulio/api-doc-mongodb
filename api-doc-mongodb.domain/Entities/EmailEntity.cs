namespace api_doc_mongodb.domain.Entities
{
    public class EmailEntity
    {
        public EmailEntity()
        {
        }
        public List<string> To { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
