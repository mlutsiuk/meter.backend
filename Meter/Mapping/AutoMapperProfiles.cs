using AutoMapper;
using Meter.Dtos;
using Meter.Models;
using Meter.Requests.Group;

namespace Meter.Mapping;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<User, UserDto>();
        
        CreateMap<Role, RoleDto>();
        
        CreateMap<Group, GroupDto>();
        CreateMap<GroupCreateRequest, Group>();
        CreateMap<GroupUpdateRequest, Group>()
            .ForMember(c => c.Counters, option => option.Ignore())
            .ForMember(c => c.Owner, option => option.Ignore());;
        
        CreateMap<Counter, CounterDto>();
        
        
        CreateMap<Measure, MeasureDto>();
        
        CreateMap<Icon, IconDto>();
    }
}