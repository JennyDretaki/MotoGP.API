using MotoGP.API.Entities;

namespace MotoGP.API.Services
{
    public interface IRiderRepository
    {
        Task<IEnumerable<Rider>> GetRidersAsync();

    }
}
