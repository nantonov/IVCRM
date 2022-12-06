using Microsoft.AspNetCore.SignalR;
using NotificationService.BLL.Services.Interfaces;
using NotificationService.BLL.SignalR;

namespace NotificationService.BLL.Services
{
    public class NotificationService : INotificationService
    {
        public const string HandlingMethodURL = "ReceiveNotification";

        private readonly IHubContext<OrderNotificationHub> _hubContext;

        public NotificationService(IHubContext<OrderNotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task Send(string message)
        {
            await _hubContext.Clients.All.SendAsync(HandlingMethodURL, message);
        }
    }
}
