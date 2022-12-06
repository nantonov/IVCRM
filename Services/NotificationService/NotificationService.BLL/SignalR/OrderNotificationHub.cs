using Microsoft.AspNetCore.SignalR;

namespace NotificationService.BLL.SignalR
{
    public class OrderNotificationHub : Hub
    {
        public const string NotificationHubURL = "/orderNotificationHub";
    }
}
