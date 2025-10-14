using AutoMapper;
using StatePattern.Models;
using StatePattern.DTOs;

namespace StatePattern.Profiles
{
    public class DocumentProfile : Profile
    {
        public DocumentProfile()
        {
            CreateMap<DocumentCreateDto, Document>()
                .ForMember(dest => dest.StateType, opt => opt.MapFrom(src => StatePattern.Models.Enums.DocumentStateType.Draft))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<Document, DocumentDto>()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.UserName))
                .ForMember(dest => dest.ReviewerName, opt => opt.MapFrom(src => src.Reviewer != null ? src.Reviewer.UserName : null));
        }
    }
}
