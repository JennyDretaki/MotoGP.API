using MotoGP.API.Entities;

namespace MotoGP.API.Services
{
    public interface ITicketRepository
    {
        Task<(IEnumerable<Ticket>, PaginationMetadata)> GetTicketsAsync(
            string? searchQuery,
            int? countryId,
            int? raceId,
            bool? open,
            int pageNumber,
            int pageSize);

        Task<Ticket?> GetTicketAsync(int ticketId);
        void AddTicket(Ticket ticket);
        Task<bool> SaveChangesAsync();
        Task LoadRaceForTicketAsync(Ticket ticket);
        Task<IEnumerable<Ticket>> GetTicketsAsync(
            string? searchQuery,
            int? countryId,
            int? raceId,
            bool? open);
    }
}

