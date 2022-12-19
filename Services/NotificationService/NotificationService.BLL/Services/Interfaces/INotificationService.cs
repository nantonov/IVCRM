namespace NotificationService.BLL.Services.Interfaces
{
    public interface INotificationService
    {
        public Task Send(string message);
    }
}
