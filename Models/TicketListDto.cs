using MotoGP.API.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MotoGP.API.Models
{
    public class TicketListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string CountryName { get; set; }
        public string RaceName { get; set; }
        public int Number { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Paid { get; set; }
    }
}
