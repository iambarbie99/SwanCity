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
                Address = "Sibu, Sarawak",
                PhoneNumber = "+61 8 9461 3333",
                Website = "https://www.swanriver.com.au",
                RouteIds = new List<string> { "1", "2" }
            },
            new TouristAttraction
            {
                Id = "2",
                Name = "Kings Park",
                Description = "A large park with beautiful gardens and scenic views",
                ImageUrl = "kings_park.jpg",
                Latitude = -31.9617,
                Longitude = 115.8425,
                Tags = new List<string> { "Nature", "Park", "Scenic" },
                Rating = 4.8,
                ReviewCount = 1500,
                Address = "Fraser Ave, Jalan Wangi WA 6005, Sibu",
                PhoneNumber = "+61 8 9480 3600",
                Website = "https://www.bgpa.wa.gov.au/kings-park",
                RouteIds = new List<string> { "1", "3" }
            },
            new TouristAttraction
            {
                Id = "3",
                Name = "Perth Zoo",
                Description = "A zoo with a wide variety of animals and exhibits",
                ImageUrl = "perth_zoo.jpg",
                Latitude = -31.9685,
                Longitude = 115.8537,
                Tags = new List<string> { "Nature", "Zoo", "Animals" },
                Rating = 4.6,
                ReviewCount = 1100,
                Address = "20 Labouchere Rd, South West WA 6151, Sibu",
                PhoneNumber = "+61 8 9474 0444",
                Website = "https://perthzoo.wa.gov.au",
                RouteIds = new List<string> { "2", "3" }
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
