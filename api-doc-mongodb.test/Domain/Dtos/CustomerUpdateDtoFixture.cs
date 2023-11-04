using api_doc_mongodb.domain.Dtos;
using Bogus;

namespace api_doc_mongodb.test.Domain.Dtos
{
    public class CustomerUpdateDtoFixture
    {
        public CustomerUpdateDtoFixture()
        {
        }
        public CustomerUpdateDto CustomerUpdateDtoMock()
        {
            var CustomerUpdateDto = new Faker<CustomerUpdateDto>("pt_BR")
               .RuleFor(a => a.Email, faker => faker.Person.Email)
               .RuleFor(a => a.Name, faker => faker.Person.FirstName)
               .RuleFor(a => a.Age, faker => faker.Random.Number(30))
               .RuleFor(a => a.Doc, faker => faker.Random.Number(10000).ToString())
               .RuleFor(a => a.LastName, faker => faker.Person.LastName)
               .RuleFor(a => a.BirthDate, faker => faker.Person.DateOfBirth);

            return CustomerUpdateDto;
        }
    }
}
