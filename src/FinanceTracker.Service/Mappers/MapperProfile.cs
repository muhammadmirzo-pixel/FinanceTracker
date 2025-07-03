using AutoMapper;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Service.DTOs.UserDTOs;

namespace FinanceTracker.Service.Mappers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        // User
        CreateMap<User, UserForCreationDto>();
        CreateMap<User, UserForResultDto>();
        CreateMap<User, UserForUpdateDto>();
        CreateMap<User, UserForVerifyDto>();
        CreateMap<User, UserForLoginDto>();

        // 
    }
}
