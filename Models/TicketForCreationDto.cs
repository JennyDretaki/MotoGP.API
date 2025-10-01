using System.ComponentModel.DataAnnotations;

namespace MotoGP.API.Models
{
    public class TicketForCreationDto
    {
        [Required(ErrorMessage = "{0} is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "{0} is required.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "{0} is required.")]
        public int CountryId { get; set; }
        [Required(ErrorMessage = "{0} is required.")]
        public int RaceId { get; set; }
        [Required(ErrorMessage = "{0} is required.")]
        public int Number { get; set; }
    }
}
