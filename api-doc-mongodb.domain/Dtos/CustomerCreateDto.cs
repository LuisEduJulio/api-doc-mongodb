namespace api_doc_mongodb.domain.Dtos
{
    public class CustomerCreateDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Doc { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
    }
}
