namespace MotoGP.API.Models
{
    public class TeamDetailsDto
       {
           public int? Id { get; set; }
           public string? Name { get; set; }
           public ICollection<SponsorDto> Sponsors { get; set; }
       }
   
} 
