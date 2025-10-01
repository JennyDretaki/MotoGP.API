namespace MotoGP.API.Services
{
    public interface IRaceRepository
    {
        Task<IEnumerable<Race>> GetRacesAsync();
        Task<Race?> GetRaceAsync(int raceId);
        Task<bool> RaceExistsAsync(int raceId);
    }
}
