using AuthorizationService.BLL;
using IdentityModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddServices(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy(options.DefaultPolicyName,
                                            policy => policy.AllowAnyOrigin()
                                                    .AllowAnyHeader()
                                                    .AllowAnyMethod());
});

builder.Services.AddAuthentication();

builder.Services.AddIdentitySetup();
builder.Services.AddIdentityServerSetup(builder.Configuration);

var app = builder.Build();

app.InitializeDatabase();

if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseIdentityServer();
app.UseAuthorization();

app.UseCors();
/*
app.UseCsp(options => options.DefaultSources(s => s.Self())
    .ConnectSources(s => s.CustomSources("wss://localhost:44348/IdentityServer/"))
    .ConnectSources(s => s.CustomSources("wss://localhost:44390/IdentityServer/")));
*/
app.UseRouting();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
