using AutoMapper;
using MotoGP.API.Entities;
using MotoGP.API.Models;

namespace MotoGP.API.MappingProfiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryDto>();
            CreateMap<CountryDto, Country>();
        }
    }
}
