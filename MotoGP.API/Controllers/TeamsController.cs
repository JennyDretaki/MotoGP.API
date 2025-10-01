using Microsoft.AspNetCore.Mvc;
using MotoGP.API.Services;
using AutoMapper;
using MotoGP.API.Models;

namespace MotoGP.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;

        public TeamsController(ITeamRepository teamRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamListDto>>> GetTeams()
        {
            var teams = await _teamRepository.GetTeamsAsync();
            return Ok(_mapper.Map<IEnumerable<TeamListDto>>(teams));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeamDetailsDto>> GetTeam(int id, [FromQuery] TeamInclude include = TeamInclude.None)
        {
            var team = await _teamRepository.GetTeamAsync(id, include);
            if (team == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<TeamDetailsDto>(team));
        }

        [HttpGet("{id}/sponsors")]
        public async Task<ActionResult<IEnumerable<SponsorDto>>> GetSponsorsForTeam(int id)
        {
            var team = await _teamRepository.GetTeamAsync(id, TeamInclude.Sponsors);
            if (team == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<SponsorDto>>(team.Sponsors));
        }
    }
}
