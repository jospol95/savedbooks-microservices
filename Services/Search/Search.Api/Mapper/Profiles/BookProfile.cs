using AutoMapper;
using Search.Api.Models;

namespace Search.Api.Mapper.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<GoogleBookItem, BookResponseLight>()
                .ForMember(
                    dest => dest.Title,
                    opt => opt.MapFrom(src => src.VolumeInfo.Title)
                )
                .ForMember(
                    //Mapping just to the 1st author (most relevant).
                    dest => dest.Author,
                    opt => opt.MapFrom(src => src.VolumeInfo.Authors[0])
                )
                .ForMember(
                    dest => dest.Description,
                    opt => opt.MapFrom(src => src.VolumeInfo.Description)
                );
        }
    }
}
