   using AutoMapper;
   using MotoGP.API.Entities;
   using MotoGP.API.Models;

   public class RiderProfile : Profile
   {
       public RiderProfile()
       {
           CreateMap<Rider, RiderListDto>()
               .ForMember(dest => dest.FlagNumber, opt => opt.MapFrom(src => src.CountryId));
       }
   }
   