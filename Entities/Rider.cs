using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoGP.API.Entities
{
    public class Rider
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string LastName { get; set; }

        [Required, MaxLength(100)]
        public string FirstName { get; set; } 

        public int Number { get; set; }
        [ForeignKey("TeamId")]
        public int TeamId { get; set; }
        public Team? Team { get; set; }
        [ForeignKey("CountryId")]
        public int CountryId { get; set; }
        public Country? Country { get; set; }
        public Rider(string lastName, string firstName)
        {
            LastName = lastName;
            FirstName = firstName;
        }

    }


}
