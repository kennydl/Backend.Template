namespace Backend.Template.Domain.Location
{
    public class Geolocation
    {
        public string Id { get; set; }
        public string Address { get; set; } = "";
        public double Latitude { get; set; }
        public double Longitude { get; set; }        
    }
}
