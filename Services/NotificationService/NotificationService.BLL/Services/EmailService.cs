using System.Net;
using System.Net.Mail;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using NotificationService.BLL.Models;
using NotificationService.BLL.Services.Interfaces;
using NotificationService.BLL.Templates;
using RazorLight;

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

        public async Task SendEmailAsync(CreateOrderMail request)
        {
            var emailMessage = await PrepareMailMessage(request);

            using (var client = ConfigureSmtpClient())
            {
                await client.SendMailAsync(emailMessage);
            }
        }

        private SmtpClient ConfigureSmtpClient()
        {
            var client = new SmtpClient(_config.Server, _config.Port);
            client.Credentials = new NetworkCredential(_config.SenderEmail, _config.Password);
            client.EnableSsl = _config.Ssl;

            return client;
        }

        private async Task<MailMessage> PrepareMailMessage(CreateOrderMail request)
        {
            var emailMessage = new MailMessage();

            emailMessage.From = new MailAddress(_config.SenderEmail, _config.SenderName);
            emailMessage.To.Add(new MailAddress(request.Email));
            emailMessage.Subject = request.Subject;
            emailMessage.IsBodyHtml = true;
            emailMessage.Body = await GetFilledTemplate(request.Message);

            return emailMessage;
        }

        private async Task<string> GetFilledTemplate(string message)
        {
            string template = EmailTemplates.DefaultEmailTemplate;

            RazorLightEngine engine = new RazorLightEngineBuilder()
                .UseEmbeddedResourcesProject(Assembly.GetEntryAssembly())
                .Build();

            string result = await engine.CompileRenderStringAsync(
                "cacheKey",
                template,
                message
                );

            return result;
        }
    }
}
