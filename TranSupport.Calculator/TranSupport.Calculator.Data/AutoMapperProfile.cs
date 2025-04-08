using AutoMapper;
using TranSupport.Calculator.Data.Entities;
using TranSupport.Calculator.Shared.Models.Projects;
using TranSupport.Calculator.Shared.Models.Users;

namespace TranSupport.Calculator.Data;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<User, UserDto>().PreserveReferences().MaxDepth(2).ReverseMap()
            .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id));
        CreateMap<UserDto, UserCreateDto>().PreserveReferences().MaxDepth(2).ReverseMap();

        CreateMap<ProjectDto, Project>().ReverseMap();
        CreateMap<CreateProjectDto, Project>();
        CreateMap<UpdateProjectDto, Project>();
    }
}
