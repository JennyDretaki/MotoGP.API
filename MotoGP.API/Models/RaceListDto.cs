namespace MotoGP.API.Models
{ 
    public class RaceListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDate { get; set; }
        public int Month { get; set; }
        public object LapTime { get; internal set; }
        public object AvgSpeed { get; internal set; }
    }

}
    