using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

var appsettingsConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var ocelotConfig = new ConfigurationBuilder().AddJsonFile("ocelot.json").Build();
var identityServerUrl = appsettingsConfig["IdentityServerURL"];

builder.Services.AddOcelot(ocelotConfig).AddCacheManager(options => options.WithDictionaryHandle());
/*
builder.Services.AddAuthentication()
    .AddJwtBearer("Identity", x =>
    {
        x.Authority = identityServerUrl;
        x.RequireHttpsMetadata = false;
        x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        {
            ValidateAudience = false,
            ValidateIssuer = true,
            ValidIssuer = identityServerUrl
        };
    });
*/
builder.Services.AddCors(config =>
{
    config.AddPolicy("DefaultPolicy",
        builder =>
        {
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerForOcelot(ocelotConfig);

var app = builder.Build();

app.UseSwaggerForOcelotUI(opt =>
{
    opt.PathToSwaggerGenerator = "/swagger/docs";
});

app.UseRouting();

app.UseAuthentication();

app.UseCors("DefaultPolicy");

app.MapGet("/", () => "Ocelot API Gateway");
await app.UseOcelot();
app.Run();
