using SwanCity.Models;
using System.Collections.ObjectModel;

namespace SwanCity.Services
{
    public class AttractionService
    {
        private readonly List<TouristAttraction> _attractions = new()
        {
            new TouristAttraction
            {
                Id = "1",
                Name = "Swan River",
                Description = "Beautiful river running through the city",
                ImageUrl = "swan_river.jpg",
                Latitude = -31.9523,
                Longitude = 115.8613,
                Tags = new List<string> { "Nature", "River", "Scenic" },
                Rating = 4.7,
                ReviewCount = 1200,
                Address = "Perth, Western Australia",
                PhoneNumber = "+61 8 9461 3333",
                Website = "https://www.swanriver.com.au",
                RouteIds = new List<string> { "1", "2" }
            },
            // Add more attractions here
        };

        public ObservableCollection<TouristAttraction> GetAttractions()
        {
            return new ObservableCollection<TouristAttraction>(_attractions);
        }

        public ObservableCollection<TouristAttraction> GetAttractionsByRoute(string routeId)
        {
            return new ObservableCollection<TouristAttraction>(
                _attractions.Where(a => a.RouteIds.Contains(routeId)));
        }

        public TouristAttraction? GetAttraction(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("Attraction ID cannot be null or empty");
            }

            return _attractions.FirstOrDefault(a => a.Id == id);
        }
    }
}
