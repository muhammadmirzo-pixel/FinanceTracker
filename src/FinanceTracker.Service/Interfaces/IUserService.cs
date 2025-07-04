using FinanceTracker.Service.Configuration;
using FinanceTracker.Service.DTOs.UserDTOs;

namespace FinanceTracker.Service.Interfaces;

public  interface IUserService
{
    Task<bool> RemoveAsync(long id);
    Task<UserForResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<UserForResultDto>> RetrieveAllAsync(PageService page);
    Task<UserForResultDto> AddAsync(UserForCreationDto dto);
    Task<UserForResultDto> RetrieveByNameAsync(string name);
    Task<UserForResultDto> ModifyAsync(long id, UserForUpdateDto dto);
}
