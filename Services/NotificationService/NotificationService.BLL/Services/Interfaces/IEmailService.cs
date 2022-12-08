using NotificationService.BLL.Models;

namespace NotificationService.BLL.Services.Interfaces
{
    public interface IEmailService
    {
        public Task SendEmailAsync(MailModel request);
    }
}
