using Microsoft.AspNetCore.Mvc;
using NotificationService.BLL.Models;
using NotificationService.BLL.Services.Interfaces;

namespace NotificationService.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IEmailService _emailService;

        public NotificationController(INotificationService notificationService, IEmailService emailService)
        {
            _notificationService = notificationService;
            _emailService = emailService;
        }

        [HttpPost("orderStatus")]
        public async Task<IActionResult> Notify([FromBody] int orderCount)
        {
            await _notificationService.Send(orderCount.ToString());

            return Ok(orderCount);
        }

        [HttpPost("email")]
        public async Task<IActionResult> NotifyByEmail([FromBody] MailModel request)
        {
            await _emailService.SendEmailAsync(request);

            return Ok(request);
        }
    }
}
