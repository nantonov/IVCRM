using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotificationService.BLL.Services.Interfaces;
using NotificationService.BLL.Services;


namespace NotificationService.BLL
{
    public static class ServiceCollectionRegistry
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<INotificationService, Services.NotificationService>();
            services.AddSingleton<IEmailService, EmailService>();
        }
    }
}
