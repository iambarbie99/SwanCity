using SwanCity.ViewModels;

namespace SwanCity.Views
{
    public partial class TripPlannerPage : ContentPage
    {
        public TripPlannerPage()
        {
            InitializeComponent();
            BindingContext = new TripPlannerViewModel();
        }
    }
}
