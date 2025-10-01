using System.ComponentModel.DataAnnotations;

namespace MotoGP.API.Models
{
    public class TicketForUpdateDto
    {
        [Required]
        public bool Paid { get; set; }
    }
}
