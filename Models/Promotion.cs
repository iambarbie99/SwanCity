namespace SwanCity.Models
{
    public class Promotion
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime ValidUntil { get; set; }
        
        public double DaysRemaining
        {
            get
            {
                var totalDays = (ValidUntil - DateTime.Now).TotalDays;
                var daysRemaining = Math.Max(0, Math.Min(1, totalDays / 30)); // Normalize to 0-1 range for 30 days
                return daysRemaining;
            }
        }
    }
}
