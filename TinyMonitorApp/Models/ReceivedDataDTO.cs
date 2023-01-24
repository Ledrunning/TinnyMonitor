namespace TinyMonitorApp.Models
{
    public class ReceivedDataDto
    {
        public string IndorTemperature { get; set; }
        public string OutdoorTemperature { get; set; }
        public string Humidity { get; set; }
        public string LightLevel { get; set; }
        public string RawText { get; set; }
    }
}