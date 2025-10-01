using System.ComponentModel.DataAnnotations;

namespace MotoGP.API.Models
{
    public class CountryDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
