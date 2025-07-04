using AutoMapper;
using FinanceTracke.Data.AppsDbContext;
using FinanceTracke.Data.IRepositories;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Service.DTOs.UserDTOs;
using FinanceTracker.Service.Exceptions;
using FinanceTracker.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Service.Services;

public class UserService(
    IMapper mapper,
    IRepository<User> repository,
    AppDbContext dbContext) : IUserService
{
    public async Task<UserForResultDto> AddAsync(UserForCreationDto dto)
    {
        var email = dto.Email;

        var isUserEmailExist = await dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == dto.Email);

        if (isUserEmailExist is not null)
            throw new CustomException(409, "User already exist");

        var isPhoneNumberExists = await dbContext.Users
           .AsNoTracking()
           .AnyAsync(x => x.PhoneNumber == dto.PhoneNumber);

        if (isPhoneNumberExists)
            throw new CustomException(406, "This number is already exist.");

        var mappedUser = mapper.Map<User>(dto);
        mappedUser.CreatedAt = DateTime.UtcNow;

        var createdUser = await repository.InsertAsync(mappedUser);

        return mapper.Map<UserForResultDto>(createdUser);
    }

    public async Task<UserForResultDto> ModifyAsync(long id, UserForUpdateDto dto)
    {
        var user = await repository.SelectAll()
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
        if (user is null)
            throw new CustomException(404, "User not found");

        var person = mapper.Map(dto, user);
        person.UpdatedAt = DateTime.UtcNow;

        await repository.UpdateAsync(person);

        return mapper.Map<UserForResultDto>(person);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var existUser = await repository.SelectAll()
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == id);

        if (existUser is not null)
            throw new CustomException(404, "User not found");

        await repository.DeleteAsync(id);

        return true;
    }

    public async Task<IEnumerable<UserForResultDto>> RetrieveAllAsync(PageService page)
    {
        var users = await repository.SelectAll()
                .AsNoTracking()
                .OrderByDescending(u => u.CreatedAt)
                .Skip((page.PageNumber - 1) * page.PageSize)
                .Take(page.PageSize)
                .ToListAsync();

        return mapper.Map<IEnumerable<UserForResultDto>>(users);
    }

    public async Task<UserForResultDto> RetrieveByIdAsync(long id)
    {
        var entry = await repository.SelectByIdAsync(id);
        if (entry is null)
            throw new CustomException(404, $"{entry} is not found");

        return mapper.Map<UserForResultDto>(entry);
    }

    public async Task<UserForResultDto> RetrieveByNameAsync(string name)
    {
        var entry = await repository.SelectAll()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.FirstName == name);

        if (entry is null)
            throw new CustomException(404, $"{name} - User not found");

        return mapper.Map<UserForResultDto>(entry);
    }
}
