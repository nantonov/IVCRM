using NotificationService.BLL;
using NotificationService.BLL.SignalR;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

ConfigureLogging();
builder.Logging.AddSerilog();
builder.Services.AddServices();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());

app.MapControllers();

app.MapHub<OrderNotificationHub>(OrderNotificationHub.NotificationHubURL);

app.Run();

void ConfigureLogging()
{
    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration, "Serilog")
        .CreateLogger();
}