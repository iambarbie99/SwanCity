using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using SwanCity.ViewModels;

namespace SwanCity.Views
{
    public partial class AttractionsPage : ContentPage
    {
        public AttractionsPage()
        {
            InitializeComponent();
            BindingContext = new AttractionsViewModel();
            
            if (BindingContext is AttractionsViewModel viewModel)
            {
                viewModel.Map = attractionsMap;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext is AttractionsViewModel viewModel)
            {
                viewModel.LoadAttractions();
            }
        }
    }
}
