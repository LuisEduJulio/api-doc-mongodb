using api_doc_mongodb.domain.Repositories;
using api_doc_mongodb.utility.Utils;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Mail;

namespace api_doc_mongodb.infraestructure.Repositories
{
    public class EmailSenderRepository : IEmailSenderRepository
    {
        private readonly string _smtpHost;
        private readonly int _smtpPort;
        private readonly string _smtpUsername;
        private readonly string _smtpPassword;

        private readonly ILogger<EmailSenderRepository> _logger;
        public EmailSenderRepository(ILogger<EmailSenderRepository> logger)
        {
            _smtpHost = EnvironmentHelper.GetSmptHost();
            _smtpPort = int.Parse(EnvironmentHelper.GetSmptPort());
            _smtpUsername = EnvironmentHelper.GetSmptMail();
            _smtpPassword = EnvironmentHelper.GetSmptPassword();

            _logger = logger;
        }
        public async Task<bool> SendEmailAsync(MailMessage MailMessage, string Email)
        {
            try
            {
                var smtpClient = new SmtpClient(_smtpHost, _smtpPort)
                {
                    Credentials = new NetworkCredential(_smtpUsername, _smtpPassword),
                    EnableSsl = true
                };

                var message = new MailMessage
                {
                    From = new MailAddress(_smtpUsername),
                    Subject = MailMessage.Subject,
                    IsBodyHtml = true,
                    Body = MailMessage.Body
                };

                message.To.Add(Email);

                try
                {
                    await smtpClient.SendMailAsync(message);
                    _logger.LogInformation("Email Enviado!");
                }
                catch (Exception Exception)
                {
                    _logger.LogError("Ocorreu um erro ao enviar o email: " + Exception.Message);
                    return false;
                }
            }
            catch (Exception Exception)
            {
                _logger.LogError("Ocorreu um erro ao enviar o email: " + Exception.Message);
                return false;
            }

            return true;
        }
    }
}
