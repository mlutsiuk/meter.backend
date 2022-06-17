using AutoMapper;
using Meter.Dtos;
using Meter.Models;
using Meter.Requests.Counter;
using Meter.Requests.Group;
using Meter.Requests.Icon;
using Meter.Requests.Measure;

namespace Meter.Mapping;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<User, UserDto>();
        CreateMap<User, UserWithRoleDto>();
        
        CreateMap<Role, RoleDto>();
        
        CreateMap<Group, GroupDto>();
        CreateMap<GroupCreateRequest, Group>();
        CreateMap<GroupUpdateRequest, Group>()
            .ForMember(c => c.Counters, option => option.Ignore())
            .ForMember(c => c.Owner, option => option.Ignore());
        
        CreateMap<Counter, CounterDto>();
        CreateMap<CounterCreateRequest, Counter>();
        CreateMap<CounterUpdateRequest, Counter>()
            .ForMember(c => c.Group, option => option.Ignore())
            .ForMember(c => c.Icon, option => option.Ignore())
            .ForMember(c => c.Measures, option => option.Ignore());
        
        
        CreateMap<Measure, MeasureDto>();
        CreateMap<MeasureCreateRequest, Measure>();
        CreateMap<MeasureUpdateRequest, Measure>()
            .ForMember(c => c.Counter, option => option.Ignore());
        
        CreateMap<Icon, IconDto>();
        CreateMap<IconCreateRequest, Icon>();
        CreateMap<IconUpdateRequest, Icon>()
            .ForMember(c => c.Counters, option => option.Ignore());
    }
}