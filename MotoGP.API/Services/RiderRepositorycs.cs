using Microsoft.EntityFrameworkCore;
using MotoGP.API.DBContext;
using MotoGP.API.Entities;

namespace MotoGP.API.Services
{
    public class RiderRepository : IRiderRepository
    {
        private readonly MotoGPContext _context;

        public RiderRepository(MotoGPContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Rider>> GetRidersAsync()
        {
            return await _context.Riders
                .Include(r => r.Team) // Include navigation property
                .OrderBy(r => r.LastName) // Sort by LastName
                .ToListAsync();
        }
    }
}
