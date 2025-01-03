using CommunityToolkit.Mvvm.ComponentModel;

namespace SwanCity.ViewModels
{
    public partial class WeatherViewModel : ObservableObject
    {
        [ObservableProperty]
        private string weatherCondition = "Sunny";

        [ObservableProperty]
        private string temperature = "25°C";

        [ObservableProperty]
        private string weatherImage = "sunny_weather.jpg";

        [ObservableProperty]
        private string weatherDescription = "Clear skies with plenty of sunshine";

        [ObservableProperty]
        private string currentTime = DateTime.Now.ToString("hh:mm tt");

        [ObservableProperty]
        private string humidity = "45%";

        [ObservableProperty]
        private string windSpeed = "10 km/h";

        [ObservableProperty]
        private string uvIndex = "Moderate";
    }
}
