using Microsoft.AspNetCore.Mvc;
using MotoGP.API.Services;
using AutoMapper;
using MotoGP.API.Models;

namespace MotoGP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RacesController : ControllerBase
    {
        private readonly IRaceRepository _raceRepository;
        private readonly IMapper _mapper;

        public RacesController(IRaceRepository raceRepository, IMapper mapper)
        {
            _raceRepository = raceRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RaceListDto>>> GetRaces()
        {
            var races = await _raceRepository.GetRacesAsync();
            return Ok(_mapper.Map<IEnumerable<RaceListDto>>(races));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RaceDetailsDto>> GetRace(int id)
        {
            if (!await _raceRepository.RaceExistsAsync(id))
            {
                return NotFound();
            }

            var race = await _raceRepository.GetRaceAsync(id);
            return Ok(_mapper.Map<RaceDetailsDto>(race));
        }
    }
}
