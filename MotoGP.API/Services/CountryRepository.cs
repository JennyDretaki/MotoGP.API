using Microsoft.EntityFrameworkCore;
using MotoGP.API.DBContext;
using MotoGP.API.Entities;

namespace MotoGP.API.Services
{
    public class CountryRepository : ICountryRepository
    {
        private readonly MotoGPContext _context;

        public CountryRepository(MotoGPContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Country>> GetCountriesAsync(bool onlyWithTickets)
        {
            if (onlyWithTickets)
            {
                return await _context.Countries
                    .Where(c => c.Tickets.Any())
                    .OrderBy(c => c.Name)
                    .ToListAsync();
            }

            return await _context.Countries
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        public async Task<bool> CountryExistsAsync(int countryId)
        {
            return await _context.Countries.AnyAsync(c => c.Id == countryId);
        }
        public async Task<Country?> GetCountryAsync(int id)
        {
            return await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
