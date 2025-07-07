using FinanceTracke.Data.AppsDbContext;
using FinanceTracke.Data.IRepositories;
using FinanceTracke.Data.Repositories;
using FinanceTracker.Service.Interfaces;
using FinanceTracker.Service.Mappers;
using FinanceTracker.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ServiceUrlsOptions>(
    builder.Configuration.GetSection("ServiceUrls"));

builder.Services.AddHttpClient<UserService>((sp, client) =>
{
    var config = sp.GetRequiredService<IOptions<ServiceUrlsOptions>>().Value;
    client.BaseAddress = new Uri(config.UserService);
});


builder.Services.AddDbContext<AppDbContext>(option
        => option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MapperProfile>());

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI();


app.UseRouting();
app.UseCors();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
