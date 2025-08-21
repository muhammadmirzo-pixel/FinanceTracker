using AutoMapper;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Service.Services.UserServices.Contracts.UserDTOs;

namespace FinanceTracker.Service.Mappers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        // User
        CreateMap<UserForCreationDto, User>()
            .ReverseMap();
        CreateMap<User, UserForResultDto>()
            .ReverseMap();
        CreateMap<UserForUpdateDto, User>()
            .ReverseMap();
        CreateMap<User, UserForVerifyDto>()
            .ReverseMap();
        CreateMap<User, UserForLoginDto>()
            .ReverseMap();

        // 
    }
}
