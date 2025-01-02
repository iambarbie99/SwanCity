namespace SwanCity.Models
{
    public class Promotion
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime ValidUntil { get; set; }
    }
}
