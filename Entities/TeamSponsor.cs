using MotoGP.API.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class TeamSponsor
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [ForeignKey("TeamId")]
    public int TeamId { get; set; }
    //Navigation Property
    public Team Team { get; set; }

    [ForeignKey("SponsorId")]
    public int SponsorId { get; set; }
    //Navigation Property
    public Sponsor Sponsor { get; set; }
}