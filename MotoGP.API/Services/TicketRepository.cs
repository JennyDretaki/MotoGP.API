using Microsoft.EntityFrameworkCore;
using MotoGP.API.DBContext;
using MotoGP.API.Entities;

namespace MotoGP.API.Services
{
    public class TicketRepository : ITicketRepository
    {
        private readonly MotoGPContext _context;

        public TicketRepository(MotoGPContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<Ticket>, PaginationMetadata)> GetTicketsAsync(
            string? searchQuery,
            int? countryId,
            int? raceId,
            bool? open,
            int pageNumber,
            int pageSize)
        {
            var collection = ApplyFilters(_context.Tickets.AsQueryable(), searchQuery, countryId, raceId, open);

            var totalItemCount = await collection.CountAsync();
            var paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);

            var tickets = await collection
                .OrderBy(t => t.OrderDate)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return (tickets, paginationMetadata);
        }

        public async Task<Ticket?> GetTicketAsync(int ticketId)
        {
            return await _context.Tickets
                .Include(t => t.Country)
                .Include(t => t.Race)
                .FirstOrDefaultAsync(t => t.Id == ticketId);
        }

        public void AddTicket(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public async Task LoadRaceForTicketAsync(Ticket ticket)
        {
            await _context.Entry(ticket)
                .Reference(t => t.Race)
                .LoadAsync();
        }

        public async Task<IEnumerable<Ticket>> GetTicketsAsync(
            string? searchQuery,
            int? countryId,
            int? raceId,
            bool? open)
        {
            var collection = ApplyFilters(_context.Tickets.AsQueryable(), searchQuery, countryId, raceId, open);
            return await collection.ToListAsync();
        }

        private IQueryable<Ticket> ApplyFilters(
            IQueryable<Ticket> collection,
            string? searchQuery,
            int? countryId,
            int? raceId,
            bool? open)
        {
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim();
                collection = collection.Where(t => t.Name.Contains(searchQuery) || t.Email.Contains(searchQuery));
            }

            if (countryId.HasValue)
            {
                collection = collection.Where(t => t.CountryId == countryId.Value);
            }

            if (raceId.HasValue)
            {
                collection = collection.Where(t => t.RaceId == raceId.Value);
            }

            if (open.HasValue)
            {
                collection = collection.Where(t => t.Paid == !open.Value);
            }

            return collection;
        }
    }
}
