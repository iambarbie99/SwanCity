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
                Name = "Sibu Night Market",
                Description = "Enjoy a delicious cuisine at the night market",
                Price = 75.00m,
                DurationHours = 2,
                IncludedAttractions = new List<string> { "1" },
                ImageUrl = "Resources/Images/sibu_night_market.jpg"
            },
            new TripPackage
            {
                Id = "2",
                Name = "Tua Pek Kong Temple",
                Description = "Explore the city's beautiful temple",
                Price = 120.00m,
                DurationHours = 4,
                IncludedAttractions = new List<string> { "2", "3", "4" },
                ImageUrl = "Resources/Images/tua_pek_kong.jpg"
            },
            new TripPackage
            {
                Id = "3",
                Name = "Sibu Heritage Centre",
                Description = "Visit the museum in Sibu",
                Price = 200.00m,
                DurationHours = 6,
                IncludedAttractions = new List<string> { "5", "6" },
                ImageUrl = "Resources/Images/heritage.jpg"
            },
            new TripPackage
            {
                Id = "4",
                Name = "Bukit Lima Forest Park",
                Description = "Adventure on a journey to Bukit Lima Forest Park",
                Price = 150.00m,
                DurationHours = 3,
                IncludedAttractions = new List<string> { "1", "7" },
                ImageUrl = "Resources/Images/bukit.jpg"
            },
            new TripPackage
            {
                Id = "5",
                Name = "Tiger Emperor Temple",
                Description = "Get up close with one of the most stunning temples in Sibu",
                Price = 90.00m,
                DurationHours = 5,
                IncludedAttractions = new List<string> { "8", "9" },
                ImageUrl = "Resources/Images/tiger.jpg"
            },
            new TripPackage
            {
                Id = "6",
                Name = "Star Mega Mall",
                Description = "Your ultimate destination for shopping and entertainment!",
                Price = 60.00m,
                DurationHours = 3,
                IncludedAttractions = new List<string> { "10", "11" },
                ImageUrl = "Resources/Images/star.jpg"
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
