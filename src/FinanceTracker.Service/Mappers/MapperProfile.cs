using AutoMapper;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Service.DTOs.UserDTOs;

namespace FinanceTracker.Service.Mappers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        // User
        CreateMap<UserForCreationDto, User>();
        CreateMap<User, UserForResultDto>();
        CreateMap<UserForUpdateDto, User>();
        CreateMap<User, UserForVerifyDto>();
        CreateMap<User, UserForLoginDto>();

        // 
    }
}
