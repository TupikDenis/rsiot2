using AutoMapper;
using webapi.DataTransferObjects;
using webapi.Models;

namespace webapi.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SubjectForManipulationDto, Subject>()
                .ForMember(p => p.Id, opt => opt.Ignore())
                .ForMember(p => p.Marks, opt => opt.Ignore());
            CreateMap<UserForManipulationDto, User>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.Marks, opt => opt.Ignore());
            CreateMap<MarkForManipulationDto, Mark>()
                .ForMember(a => a.Subject, opt => opt.Ignore())
                .ForMember(a => a.User, opt => opt.Ignore());
        }
    }
}
