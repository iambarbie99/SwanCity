using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Maui.Controls.Maps;
using SwanCity.Models;
using SwanCity.Services;

namespace SwanCity.ViewModels
{
    public class AttractionsViewModel : INotifyPropertyChanged
    {
        private Microsoft.Maui.Controls.Maps.Map? _map;
        public Microsoft.Maui.Controls.Maps.Map? Map
        {
            get => _map;
            set
            {
                _map = value;
                OnPropertyChanged();
            }
        }
        private readonly AttractionService _attractionService;
        private readonly NotificationService _notificationService;
        
        private ObservableCollection<TouristAttraction>? _attractions;
        public ObservableCollection<TouristAttraction>? Attractions
        {
            get => _attractions;
            set
            {
                _attractions = value;
                OnPropertyChanged();
            }
        }

        private TouristAttraction? _selectedAttraction;
        public TouristAttraction? SelectedAttraction
        {
            get => _selectedAttraction;
            set
            {
                _selectedAttraction = value;
                OnPropertyChanged();
                HandleAttractionSelection();
            }
        }

        public AttractionsViewModel()
        {
            _attractionService = new AttractionService();
            _notificationService = new NotificationService();
            LoadAttractions();
            TriggerExampleNotifications();
        }

        public void LoadAttractions()
        {
            Attractions = _attractionService.GetAttractions();
            AddPinsToMap();
        }

        private void AddPinsToMap()
        {
            if (Map == null || Attractions == null) return;

            foreach (var attraction in Attractions)
            {
                var pin = new Microsoft.Maui.Controls.Maps.Pin
                {
                    Label = attraction.Name,
                    Address = attraction.Address,
                    Location = new Microsoft.Maui.Devices.Sensors.Location(attraction.Latitude, attraction.Longitude),
                    Type = Microsoft.Maui.Controls.Maps.PinType.Place
                };
                
                if (Map != null)
                {
                    Map.Pins.Add(pin);
                }
            }
        }

        private async void HandleAttractionSelection()
        {
            if (SelectedAttraction != null)
            {
                // Notify about selected attraction
                await _notificationService.ShowNotification(
                    "Attraction Selected",
                    $"You selected {SelectedAttraction.Name}");
            }
        }

        private async void TriggerExampleNotifications()
        {
            // Example: New attraction notification
            await _notificationService.NotifyNewAttraction(new TouristAttraction
            {
                Name = "Swan Valley Vineyards",
                Description = "Explore the beautiful vineyards of Swan Valley"
            });

            // Example: Promotion notification
            await _notificationService.NotifyPromotion("50% Off Guided Tours");

            // Example: Trip reminder (1 minute from now)
            await _notificationService.NotifyTripReminder(
                "Swan River Cruise",
                DateTime.Now.AddMinutes(1));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
