using AutoMapper;
using MotoGP.API.Models;

namespace MotoGP.API.MappingProfiles
{
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            
            //.ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.Name))
            //.ForMember(dest => dest.RaceName, opt => opt.MapFrom(src => src.Race.Name));
            CreateMap<Ticket,TicketDetailsDto >();
            CreateMap<TicketForCreationDto, Ticket>();
            CreateMap<TicketForUpdateDto, Ticket>();
            CreateMap<Ticket, TicketForUpdateDto>();
        }
    }
}
