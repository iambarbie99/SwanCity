namespace SwanCity.Models
{
    public class TouristAttraction
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<string> Tags { get; set; } = new();
        public double Rating { get; set; }
        public int ReviewCount { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Website { get; set; }
        public List<string> RouteIds { get; set; } = new();
    }
}
