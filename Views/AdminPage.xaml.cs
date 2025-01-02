using Microsoft.Maui.Controls;

namespace SwanCity.Views
{
    public partial class AdminPage : ContentPage
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private async void NavigateToRoutes(object sender, EventArgs e)
        {
            // TODO: Implement routes management
            await DisplayAlert("Info", "Routes management coming soon", "OK");
        }

        private async void NavigateToPackages(object sender, EventArgs e)
        {
            // TODO: Implement packages management
            await DisplayAlert("Info", "Packages management coming soon", "OK");
        }

        private async void NavigateToPromotions(object sender, EventArgs e)
        {
            // TODO: Implement promotions management
            await DisplayAlert("Info", "Promotions management coming soon", "OK");
        }

        private async void NavigateToNotifications(object sender, EventArgs e)
        {
            // TODO: Implement notifications management
            await DisplayAlert("Info", "Notifications management coming soon", "OK");
        }

        private async void NavigateToUserView(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//TripPlannerPage");
        }
    }
}
