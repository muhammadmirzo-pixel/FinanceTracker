using FinanceTracker.Service.Services.AuthServices.Contracts.AuthDTOs;

namespace FinanceTracker.Service.Services.AuthServices.Contracts;

public interface IAuthService
{
    Task<LoginForResultDto> AuthenticateAsync (LoginDto loginDto);
}
