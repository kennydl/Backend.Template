using AutoMapper;
using Backend.Template.Api.Dto;
using Backend.Template.Core.Exceptions;

namespace Backend.Template.Api.Mappers
{
    public class LogErrorMapper : Profile
    {
        public LogErrorMapper()
        {
            CreateMap<DefaultException, ErrorDto>()
                .ForMember(
                    dst => dst.StackTrace,
                    opt => opt.MapFrom<string?>(src => null)
                );
        }
    }
}
