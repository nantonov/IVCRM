using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

var appsettingsConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var ocelotConfig = new ConfigurationBuilder().AddJsonFile("ocelot.json").Build();

builder.Services.AddOcelot(ocelotConfig).AddCacheManager(options => options.WithDictionaryHandle());

builder.Services.AddCors(config =>
{
    config.AddPolicy("DefaultPolicy",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerForOcelot(ocelotConfig);

var app = builder.Build();

app.UseSwaggerForOcelotUI(opt =>
{
    opt.PathToSwaggerGenerator = "/swagger/docs";
});

await app.UseOcelot();

app.UseRouting();

app.UseAuthentication();

app.UseCors("DefaultPolicy");

app.MapGet("/", () => "Ocelot API Gateway");

app.Run();
