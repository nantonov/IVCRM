using IVCRM.BLL;
using SPWB.IVCRM.BLL.Profiles;
using SPWB.SportService.BFF.Profiles;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<ApiMappingProfile>();
    cfg.AddProfile<BllMappingProfile>();
});

builder.Services.AddDatabaseConfig(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddServices();

builder.Services.AddControllers();
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
