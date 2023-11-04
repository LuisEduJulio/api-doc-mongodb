using api_doc_mongodb.domain.Entities;
using AutoFixture;
using MongoDB.Bson;

namespace api_doc_mongodb.test.Domain.Entities
{
    public class CustomerEntityFixture
    {
        private readonly Fixture _fixture;

        public CustomerEntityFixture()
        {
            _fixture = new Fixture();
            _fixture.Customize(new BsonObjectIdCustomization());
        }
        public CustomerEntity CustomerEntityMock()
        {
            var CustomerEntityFixture = _fixture.Create<CustomerEntity>();

            return CustomerEntityFixture;
        }
        public List<CustomerEntity> CustomerEntityListMock()
        {
            var CustomerEntityListFixture = new List<CustomerEntity>();

            for(int i = 0; i < 3; i++)
            {
                var CustomerEntityFixture = _fixture.Create<CustomerEntity>();

                CustomerEntityListFixture.Add(CustomerEntityFixture);
            }

            return CustomerEntityListFixture;
        }
    }

    public class BsonObjectIdCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Register(() => ObjectId.GenerateNewId());
        }
    }
}