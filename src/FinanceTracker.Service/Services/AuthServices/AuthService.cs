using FinanceTracker.Service.Services.AuthServices.Contracts;
using FinanceTracker.Service.Services.AuthServices.Contracts.AuthDTOs;
using FinanceTracker.Service.Services.UserServices.Contracts;
using Microsoft.Extensions.Configuration;

namespace FinanceTracker.Service.Services.AuthServices;

public class AuthService(
    IConfiguration configuration,
    IUserService userService) : IAuthService
{
    public async Task<LoginForResultDto> AuthenticateAsync(LoginDto loginDto)
    {
        // var foundUser = await userService.
        throw new NotImplementedException();
    }
}