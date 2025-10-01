namespace MotoGP.API.Models
{
    public class RaceDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDate { get; set; }
        public int Month { get; set; }
        public double TrackLength { get; set; }
        public string Description { get; set; }
        public object Date { get; internal set; }
        public object Length { get; internal set; }
        public int LapCount { get; set; }
        public double LapTime { get; set; } // Updated property name
        public double TotalDistanceKm { get; set; }
        public double AvgSpeed { get; set; } // Updated property name
        public TimeSpan Duration { get; set; } // New property
    }
}