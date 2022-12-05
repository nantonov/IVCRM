using Microsoft.AspNetCore.Mvc;
using NotificationService.BLL.Services.Interfaces;

namespace NotificationService.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost]
        public async Task<IActionResult> Notify([FromBody] string message)
        {
            await _notificationService.Send(message);

            return Ok(message);
        3}
    }
}