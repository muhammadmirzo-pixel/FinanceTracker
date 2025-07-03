using FinanceTracker.Service.Configuration;
using FinanceTracker.Service.DTOs.UserDTOs;

namespace FinanceTracker.Service.Interfaces;

public  interface IUserService
{
    Task<bool> RemoveAsync(long id);
    Task<UserForResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<UserForResultDto>> RetrieveAllAsync(Pagination page);
    Task<UserForResultDto> AddAsync(UserForCreationDto dto);
    Task<UserForResultDto> RetrieveByEmailAsync(string email);
    Task<UserForResultDto> ModifyAsync(long id, UserForUpdateDto dto);
}
