using AutoMapper;
using FinanceTracke.Data.AppsDbContext;
using FinanceTracke.Data.IRepositories;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Service.Configuration;
using FinanceTracker.Service.DTOs.UserDTOs;
using FinanceTracker.Service.Errors;
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

    public async Task<IEnumerable<UserForResultDto>> RetrieveAllAsync(Pagination page)
    {
        var users = await repository.SelectAll()
                .AsNoTracking()
                .ToPagedList(page)
                .ToListAsync();

        return mapper.Map<IEnumerable<UserForResultDto>>(users);
    }

    public Task<UserForResultDto> RetrieveByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task<UserForResultDto> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}
