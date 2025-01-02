using SwanCity.Models;
using SwanCity.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace SwanCity.ViewModels
{
    public class TripPlannerViewModel
    {
        private readonly TripPlannerService _tripPlannerService;
        private readonly AttractionService _attractionService;
        private readonly NotificationService _notificationService;

        public ObservableCollection<TripPackage> Packages { get; }
        public ObservableCollection<TouristAttraction> IncludedAttractions { get; }

        private TripPackage? _selectedPackage;
        public TripPackage? SelectedPackage
        {
            get => _selectedPackage;
            set
            {
                _selectedPackage = value;
                UpdateIncludedAttractions();
            }
        }

        public ICommand BookPackageCommand { get; }

        public TripPlannerViewModel()
        {
            _tripPlannerService = new TripPlannerService();
            _attractionService = new AttractionService();
            _notificationService = new NotificationService();
            
            Packages = _tripPlannerService.GetPackages();
            IncludedAttractions = new ObservableCollection<TouristAttraction>();

            BookPackageCommand = new Command(async () => await BookPackageAsync());
        }

        public async Task BookPackageAsync()
        {
            if (SelectedPackage != null)
            {
                // TODO: Implement actual booking logic
                await _notificationService.NotifyPackageBooked(SelectedPackage);
            }
        }

        private void UpdateIncludedAttractions()
        {
            IncludedAttractions.Clear();
            
            if (SelectedPackage != null)
            {
                foreach (var attractionId in SelectedPackage.IncludedAttractions)
                {
                    var attraction = _attractionService.GetAttraction(attractionId);
                    if (attraction != null)
                    {
                        IncludedAttractions.Add(attraction);
                    }
                }
            }
        }
    }
}
