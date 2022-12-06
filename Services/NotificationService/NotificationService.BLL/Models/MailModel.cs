using Microsoft.AspNetCore.Http;

namespace NotificationService.BLL.Models
{
    public class MailModel
    {
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
