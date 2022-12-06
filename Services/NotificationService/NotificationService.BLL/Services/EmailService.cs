using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using NotificationService.BLL.Models;
using NotificationService.BLL.Services.Interfaces;

namespace NotificationService.BLL.Services
{
    public class EmailService : IEmailService
    {
        private readonly string EmailConfigurationSection = "SmtpSettings";
        private readonly EmailConfiguration _config;

        public EmailService(IConfiguration configuration)
        {
            _config = configuration.GetSection(EmailConfigurationSection).Get<EmailConfiguration>();
        }
        public async Task SendEmailAsync(MailModel request)
        {
            var emailMessage = new MailMessage();

            emailMessage.From = new MailAddress(_config.SenderEmail, _config.SenderName);
            emailMessage.To.Add(new MailAddress("minuciusfelicis@gmail.com"));
            emailMessage.Subject = request.Subject;
            emailMessage.Body = request.Body;

            using (var client = new SmtpClient(_config.Server, _config.Port))
            {
                client.Credentials = new NetworkCredential(_config.SenderEmail, _config.Password);
                client.EnableSsl = _config.SSL;
                await client.SendMailAsync(emailMessage);
            }
        }
    }
}
