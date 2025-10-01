using MotoGP.API.Models;

namespace MotoGP.API.Models
{
    public class TeamsDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Logo { get; set; }
        public ICollection<RiderDto>? Riders { get; set; }
    }
}
