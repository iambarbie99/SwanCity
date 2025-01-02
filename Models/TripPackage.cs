namespace SwanCity.Models
{
    public class TripPackage
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int DurationHours { get; set; }
        public List<string> IncludedAttractions { get; set; } = new List<string>();
        public string? ImageUrl { get; set; }
    }
}
