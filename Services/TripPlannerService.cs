using SwanCity.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace SwanCity.Services
{
    public class TripPlannerService
    {
        private readonly List<TripPackage> _packages = new()
        {
            new TripPackage
            {
                Id = "1",
                Name = "Swan River Cruise",
                Description = "Enjoy a scenic cruise along the Swan River",
                Price = 75.00m,
                DurationHours = 2,
                IncludedAttractions = new List<string> { "1" },
                ImageUrl = "Resources/Images/swan_river_cruise.jpg"
            },
            new TripPackage
            {
                Id = "2",
                Name = "City Highlights Tour",
                Description = "Explore the city's top landmarks and attractions",
                Price = 120.00m,
                DurationHours = 4,
                IncludedAttractions = new List<string> { "2", "3", "4" },
                ImageUrl = "Resources/Images/city_highlights.jpg"
            },
            new TripPackage
            {
                Id = "3",
                Name = "Wine Country Experience",
                Description = "Visit renowned wineries and taste local varieties",
                Price = 200.00m,
                DurationHours = 6,
                IncludedAttractions = new List<string> { "5", "6" },
                ImageUrl = "Resources/Images/wine_country.jpg"
            },
            new TripPackage
            {
                Id = "4",
                Name = "Sunset Dinner Cruise",
                Description = "Romantic evening cruise with gourmet dining",
                Price = 150.00m,
                DurationHours = 3,
                IncludedAttractions = new List<string> { "1", "7" },
                ImageUrl = "Resources/Images/sunset_cruise.jpg"
            },
            new TripPackage
            {
                Id = "5",
                Name = "Wildlife Adventure",
                Description = "Get up close with native Australian wildlife",
                Price = 90.00m,
                DurationHours = 5,
                IncludedAttractions = new List<string> { "8", "9" },
                ImageUrl = "Resources/Images/wildlife_adventure.jpg"
            },
            new TripPackage
            {
                Id = "6",
                Name = "Historical Walking Tour",
                Description = "Discover the city's rich history and architecture",
                Price = 60.00m,
                DurationHours = 3,
                IncludedAttractions = new List<string> { "10", "11" },
                ImageUrl = "Resources/Images/walking_tour.jpg"
            }
        };

        public ObservableCollection<TripPackage> GetPackages()
        {
            return new ObservableCollection<TripPackage>(_packages);
        }

        public TripPackage? GetPackage(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("Package ID cannot be null or empty");
            }

            return _packages.FirstOrDefault(p => p.Id == id);
        }
    }
}
