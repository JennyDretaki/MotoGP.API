using Microsoft.EntityFrameworkCore;
using MotoGP.API.DBContext;
using MotoGP.API.Entities;

namespace MotoGP.API.Services
{
    public class TeamRepository : ITeamRepository
    {
        private readonly MotoGPContext _context;

        public TeamRepository(MotoGPContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Team>> GetTeamsAsync()
        {
            return await _context.Teams
                .Include(t => t.Sponsors) // Include navigation property
                .OrderBy(t => t.Name) // Sort by Name
                .ToListAsync();
        }

        public async Task<Team?> GetTeamAsync(int teamId, TeamInclude include = TeamInclude.None)
        {
            IQueryable<Team> query = _context.Teams;

            switch (include)
            {
                case TeamInclude.Riders:
                    query = query.Include(t => t.Riders);
                    break;
                case TeamInclude.Sponsors:
                    query = query.Include(t => t.Sponsors);
                    break;
            }

            return await query.FirstOrDefaultAsync(t => t.Id == teamId);
        }
    }
}
