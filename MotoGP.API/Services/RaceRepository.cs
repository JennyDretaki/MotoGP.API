using Microsoft.EntityFrameworkCore;
using MotoGP.API.DBContext;
using MotoGP.API.Entities;

namespace MotoGP.API.Services
{
    public class RaceRepository : IRaceRepository
    {
        private readonly MotoGPContext _context;

        public RaceRepository(MotoGPContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Race>> GetRacesAsync()
        {
            return await _context.Races
                .OrderBy(r => r.Name) // Sort by Name
                .ToListAsync();
        }

        public async Task<Race?> GetRaceAsync(int raceId)
        {
            return await _context.Races
                .FirstOrDefaultAsync(r => r.Id == raceId);
        }

        public async Task<bool> RaceExistsAsync(int raceId)
        {
            return await _context.Races.AnyAsync(r => r.Id == raceId);
        }
    }
}
