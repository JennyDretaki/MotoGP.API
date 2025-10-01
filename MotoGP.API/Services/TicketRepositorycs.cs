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

        public async Task<IEnumerable<Ticket>> GetTicketsAsync()
        {
            return await _context.Tickets
                .Include(t => t.Country)
                .Include(t => t.Race)
                .OrderBy(t => t.OrderDate)
                .ToListAsync();
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
    }
}


