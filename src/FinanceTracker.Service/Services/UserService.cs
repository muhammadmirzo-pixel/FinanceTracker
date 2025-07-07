using AutoMapper;
using FinanceTracke.Data.AppsDbContext;
using FinanceTracke.Data.IRepositories;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Service.DTOs.UserDTOs;
using FinanceTracker.Service.Exceptions;
using FinanceTracker.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FinanceTracker.Service.Services;

public class UserService(
    IMapper mapper,
    IRepository<User> repository,
    AppDbContext dbContext,
    HttpClient httpClient,
    IHttpContextAccessor httpContextAccessor,
    IConfiguration configuration) : IUserService
{
    public async Task<UserForResultDto> AddAsync(UserForCreationDto dto)
    {
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

        if (existUser is null)
            throw new CustomException(404, "User not found");

        await repository.DeleteAsync(id);

        return true;
    }

    public async Task<IEnumerable<UserForResultDto>> RetrieveAllAsync(PageService page)
    {
        // 1. Tokenni olish
        var token = httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();

        Console.WriteLine($"Token ===> {token}");

        if (string.IsNullOrEmpty(token))
            throw new CustomException(401, "Authorization token not found.");

        // 2. So‘rov tayyorlash
        var request = new HttpRequestMessage(HttpMethod.Get, $"{configuration["Scoring:BaseUrl"]}/users");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.Replace("Bearer ", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJpbm4tb3ItcGluZmwiOiIxMjM0NTY3ODkxMDExMSIsImxhbmciOiJ1eiIsImV4cCI6ODk0OTYxOTg5NiwiaXNzIjoiZGV2LmVkY29tLnV6IiwiYXVkIjoiZGV2LmVkY29tLnV6In0.z8bJOepjm6Iyi-q1PMRmtX4dVhXevjKnrj_ZMsalHcc"));

        // 3. So‘rov yuborish
        var response = await httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        // 4. Natijani o‘qish
        var content = await response.Content.ReadAsStringAsync();
        var users = JsonConvert.DeserializeObject<List<UserForResultDto>>(content);

        return users;

        /*var users = await repository.SelectAll()
                .AsNoTracking()
                .OrderByDescending(u => u.CreatedAt)
                .Skip((page.PageNumber - 1) * page.PageSize)
                .Take(page.PageSize)
        return mapper.Map<IEnumerable<UserForResultDto>>(users);  */ .ToListAsync();
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
