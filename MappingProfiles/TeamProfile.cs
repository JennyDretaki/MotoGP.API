using AutoMapper;
using MotoGP.API.Entities;
using MotoGP.API.Models;

public class TeamProfile : Profile
{
    public TeamProfile()
    {
        CreateMap<Team, TeamDetailsDto>()
           .ForMember(dest => dest.Sponsors, opt => opt.MapFrom(src => src.Sponsors));
        CreateMap<Sponsor, SponsorDto>();
    }
}
