using Microsoft.AspNetCore.Mvc;
using MotoGP.API.Services;
using AutoMapper;
using MotoGP.API.Models;

namespace MotoGP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountriesController(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryDto>>> GetCountries([FromQuery] bool onlyWithTickets = false)
        {
            var countries = await _countryRepository.GetCountriesAsync(onlyWithTickets);
            return Ok(_mapper.Map<IEnumerable<CountryDto>>(countries));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDto>> GetCountry(int id)
        {
            if (!await _countryRepository.CountryExistsAsync(id))
            {
                return NotFound();
            }

            var country = await _countryRepository.GetCountryAsync(id);
            return Ok(_mapper.Map<CountryDto>(country));
        }
        
    }
}

