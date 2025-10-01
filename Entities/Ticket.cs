using MotoGP.API.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Ticket
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    public int CountryId { get; set; }

    [ForeignKey("CountryId")]
    public Country Country { get; set; }  // Navigation property

    [Required]
    public int RaceId { get; set; }

    [ForeignKey("RaceId")]
    public Race Race { get; set; }  // Navigation property

    [Required]
    public int Number { get; set; }  // Number of tickets

    [Required]
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;  // Default to current date

    [Required]
    public bool Paid { get; set; } = false;  // Default to unpaid

    // Constructor
    public Ticket(string name)
    {
        Name = name;
    }
}
