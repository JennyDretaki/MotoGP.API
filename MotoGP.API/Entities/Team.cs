using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoGP.API.Entities
{
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } 
        public string? Logo { get; set; }

        //Navigation Properties
        public ICollection<Rider> Riders { get; set; } = new List<Rider>();
        public ICollection<TeamSponsor> TeamSponsors { get; set; } = new List<TeamSponsor>();
        public ICollection<Sponsor> Sponsors { get; set; } = new List<Sponsor>();
        public Team (string name)
        {
            Name = name;
        }
    }
}
