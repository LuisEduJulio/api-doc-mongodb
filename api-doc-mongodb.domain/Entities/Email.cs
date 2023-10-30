namespace api_doc_mongodb.domain.Entities
{
    public class Email
    {
        public Email()
        {
        }
        public List<string> To { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
