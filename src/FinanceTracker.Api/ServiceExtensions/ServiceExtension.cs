using FinanceTracke.Data.IRepositories;
using FinanceTracke.Data.Repositories;
using FinanceTracker.Service.Services.UserService;
using FinanceTracker.Service.Services.UserServices.Contracts;

namespace FinanceTracker.Api.ServiceExtensions;

public static class ServiceExtension
{ 
    public static void AddCustomService(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUserService, UserService>();
    }
}
