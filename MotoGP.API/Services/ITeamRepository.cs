using MotoGP.API.Entities;
using static MotoGP.API.Services.TeamRepository;

namespace MotoGP.API.Services
{
    public interface ITeamRepository
    {

        Task<IEnumerable<Team>> GetTeamsAsync();
        Task<Team?> GetTeamAsync(int teamId, TeamInclude include = TeamInclude.None);
    }
    public enum TeamInclude
    {
        None,
        Riders,
        Sponsors
    }
}