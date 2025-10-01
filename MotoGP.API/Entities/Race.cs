using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Race
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Place { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public int Length { get; set; }

    [Required]
    public int X { get; set; }

    [Required]
    public int Y { get; set; }
    [Required]
    public int LapCount { get; set; } //the number of laps of the race 
    [Required]
  
    public double AvgSpeed { get; set; } //the estimated average speed in km/
    public double LapTime { get; set; } //the estimated time in seconds of one lap 


    [Required]
    public DateTime Date { get; set; }
    public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
   

    public Race(string name)
    {
        Name = name;
    }
}
