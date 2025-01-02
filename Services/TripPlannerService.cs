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
                ImageUrl = "swan_river_cruise.jpg"
            },
            // Add more packages here
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
