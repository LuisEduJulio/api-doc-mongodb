using api_doc_mongodb.domain.Entities;
using AutoFixture;
using System.Net.Mail;

namespace api_doc_mongodb.test.Domain.Entities
{
    public class EmailEntityFixture
    {
        private readonly Fixture _fixture;

        public EmailEntityFixture()
        {
            _fixture = new Fixture();
        }
        public MailMessage EmailEntityMock()
        {
            var EmailEntityFixture = _fixture.Create<MailMessage>();

            return EmailEntityFixture;
        }
    }
}