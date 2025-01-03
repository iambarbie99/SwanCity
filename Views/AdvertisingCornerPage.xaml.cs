using SwanCity.ViewModels;

namespace SwanCity.Views
{
    public partial class AdvertisingCornerPage : ContentPage
    {
        public AdvertisingCornerPage(AdvertisingCornerViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
