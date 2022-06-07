using AutoMapper;
using Meter.Dtos;
using Meter.Models;

namespace Meter.Mapping;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<User, UserDto>();
        
        CreateMap<Role, RoleDto>();
        
        CreateMap<Group, GroupDto>();
        
        CreateMap<Counter, CounterDto>();
        
        CreateMap<Measure, MeasureDto>();
        
        CreateMap<Icon, IconDto>();
    }
}