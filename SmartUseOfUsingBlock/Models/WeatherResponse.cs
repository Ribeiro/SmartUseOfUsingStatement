namespace SmartUseOfUsingBlock.Models
{
    public class WeatherResponse
    {
        public Coord coord { get; set; }
        public IList<Weather> weather { get; set; }
        public int visibility { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public int dt { get; set; }
        public int timezone { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }
}
