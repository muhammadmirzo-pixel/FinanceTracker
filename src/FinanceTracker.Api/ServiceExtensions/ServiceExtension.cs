using FinanceTracke.Data.IRepositories;
using FinanceTracke.Data.Repositories;
using FinanceTracker.Service.Interfaces;
using FinanceTracker.Service.Services;

namespace FinanceTracker.Api.ServiceExtensions;

public static class ServiceExtension
{ 
    public static void AddCustomService(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUserService, UserService>();
    }
}
