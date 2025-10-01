using AutoMapper;
using MotoGP.API.Entities;
using MotoGP.API.Models;

namespace MotoGP.API.MappingProfiles
{
    public class RaceProfile : Profile
    {
        public RaceProfile()
        {
            CreateMap<Race, RaceDetailsDto>()
                .ForMember(dest => dest.AvgSpeed, opt => opt.MapFrom(src => src.AvgSpeed))
                .ForMember(dest => dest.LapTime, opt => opt.MapFrom(src => src.LapTime))
                .ForMember(dest => dest.Duration, opt => opt.Ignore()); // Assuming Duration is calculated separately

            CreateMap<RaceDetailsDto, Race>()
                .ForMember(dest => dest.AvgSpeed, opt => opt.MapFrom(src => src.AvgSpeed))
                .ForMember(dest => dest.LapTime, opt => opt.MapFrom(src => src.LapTime));

            CreateMap<Race, RaceListDto>()
                .ForMember(dest => dest.AvgSpeed, opt => opt.MapFrom(src => src.AvgSpeed))
                .ForMember(dest => dest.LapTime, opt => opt.MapFrom(src => src.LapTime));

            CreateMap<RaceListDto, Race>()
                .ForMember(dest => dest.AvgSpeed, opt => opt.MapFrom(src => src.AvgSpeed))
                .ForMember(dest => dest.LapTime, opt => opt.MapFrom(src => src.LapTime));
        }
    }
}
