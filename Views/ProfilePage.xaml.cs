using SwanCity.ViewModels;

namespace SwanCity.Views
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            BindingContext = new ProfileViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext is ProfileViewModel viewModel)
            {
                await viewModel.LoadProfileAsync();
            }
        }
    }
}
