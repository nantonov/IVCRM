using FluentValidation;
using IVCRM.API.Filters;
using IVCRM.API.Middlewares;
using IVCRM.API.Profiles;
using IVCRM.BLL;
using IVCRM.BLL.Profiles;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using IVCRM.API;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<ApiMappingProfile>();
    cfg.AddProfile<BllMappingProfile>();
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://localhost:7237";
        options.RequireHttpsMetadata = false;
        options.Audience = "ProductAPI";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddServices(builder.Configuration);

builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: "client", builder =>
    {
        builder.WithOrigins("http://localhost/7025")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddMassTransit(x =>
{
    x.SetKebabCaseEndpointNameFormatter();
    x.UsingRabbitMq();
});

builder.Services.AddControllers();

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerWithSecurity(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "ProductionAPI");

        options.OAuthClientId("swaggerClient");
        options.OAuthAppName("Swagger");
        options.OAuthUsePkce();
    });
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseCors("client");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
