using System.Net.Mail;

namespace api_doc_mongodb.domain.Repositories
{
    public interface IEmailSenderRepository
    {
        Task<bool> SendEmailAsync(MailMessage MailMessage, string Email);
    }
}
