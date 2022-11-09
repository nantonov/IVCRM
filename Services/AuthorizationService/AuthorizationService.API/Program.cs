using AuthorizationService.API;
using AuthorizationService.BLL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddServices(builder.Configuration);

builder.Services.AddIdentitySetup();
builder.Services.AddIdentityServerSetup();

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

app.UseRouting();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
