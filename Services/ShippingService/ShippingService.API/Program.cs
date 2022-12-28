using FluentValidation;
using ShippingService.API.Profiles;
using ShippingService.BLL;
using ShippingService.BLL.Profiles;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<ApiMappingProfile>();
    cfg.AddProfile<BllMappingProfile>();
});

builder.Services.AddServices(builder.Configuration);
builder.Services.AddMediatR();
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: "client", builder =>
    {
        builder.WithOrigins("http://localhost:7025")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddControllers();

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
