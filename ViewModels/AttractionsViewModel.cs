using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Maui.Controls.Maps;
using SwanCity.Models;
using SwanCity.Services;

namespace SwanCity.ViewModels
{
    public partial class AttractionsViewModel : INotifyPropertyChanged
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
            try
            {
                Console.WriteLine("Initializing AttractionsViewModel...");
                
                _attractionService = new AttractionService();
                if (_attractionService == null)
                {
                    throw new Exception("Failed to initialize AttractionService");
                }
                Console.WriteLine("AttractionService initialized successfully");

                _notificationService = new NotificationService();
                if (_notificationService == null)
                {
                    throw new Exception("Failed to initialize NotificationService");
                }
                Console.WriteLine("NotificationService initialized successfully");

                InitializeMap();
                LoadAttractions();
                TriggerExampleNotifications();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing AttractionsViewModel: {ex}");
                throw;
            }
        }

        private void InitializeMap()
        {
            try
            {
                Console.WriteLine("Initializing Map...");
                Map = new Microsoft.Maui.Controls.Maps.Map();
                if (Map == null)
                {
                    throw new Exception("Failed to initialize Map");
                }
                Console.WriteLine("Map initialized successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing Map: {ex}");
                throw;
            }
        }

        public void LoadAttractions()
        {
            var attractions = _attractionService?.GetAttractions();
            if (attractions != null)
            {
                Attractions = new ObservableCollection<TouristAttraction>(attractions);
                AddPinsToMap();
            }
        }

        private void AddPinsToMap()
        {
            try
            {
                if (Map is null)
                {
                    Console.WriteLine("Map is null in AddPinsToMap");
                    return;
                }

                if (Attractions is null)
                {
                    Console.WriteLine("Attractions is null in AddPinsToMap");
                    return;
                }

                if (Map.Pins is null)
                {
                    Console.WriteLine("Map.Pins is null in AddPinsToMap");
                    return;
                }

                foreach (var attraction in Attractions)
                {
                    if (attraction?.Name == null || attraction?.Address == null)
                    {
                        Console.WriteLine($"Skipping attraction with null Name or Address");
                        continue;
                    }

                    var pin = new Microsoft.Maui.Controls.Maps.Pin
                    {
                        Label = attraction.Name ?? "Unknown Attraction",
                        Address = attraction.Address ?? "Unknown Address",
                        Location = new Microsoft.Maui.Devices.Sensors.Location(
                            IsValidLatitude(attraction.Latitude) ? attraction.Latitude : 2.3409946, // Default to Perth coordinates
                            IsValidLongitude(attraction.Longitude) ? attraction.Longitude : 111.8449278),
                        Type = Microsoft.Maui.Controls.Maps.PinType.Place
                    };
                    
                    Map.Pins.Add(pin);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddPinsToMap: {ex}");
                throw;
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

        private bool IsValidLatitude(double? latitude)
        {
            return latitude.HasValue && latitude >= -90 && latitude <= 90;
        }

        private bool IsValidLongitude(double? longitude)
        {
            return longitude.HasValue && longitude >= -180 && longitude <= 180;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
