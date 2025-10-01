using MotoGP.API.Entities;

namespace MotoGP.API.Services
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetCountriesAsync(bool onlyWithTickets);
        Task<Country?> GetCountryAsync(int countryId);
        Task<bool> CountryExistsAsync(int countryId);
        //Task<Country?> GetCountryAsync(int id);
    }
}
