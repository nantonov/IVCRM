using Microsoft.AspNetCore.Http;

namespace NotificationService.BLL.Models
{
    public class MailModel
    {
        public string Email { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string Message { get; set; } = null!;
    }
}
