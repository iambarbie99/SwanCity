using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using SwanCity.ViewModels;

namespace SwanCity.Views
{
    public partial class AttractionsPage : ContentPage
    {
        public AttractionsPage()
        {
            try
            {
                Console.WriteLine("Initializing AttractionsPage...");
                InitializeComponent();
                
                var viewModel = new AttractionsViewModel();
                BindingContext = viewModel;
                
                if (attractionsMap != null)
                {
                    viewModel.Map = attractionsMap;
                    Console.WriteLine("Map successfully assigned to ViewModel");
                }
                else
                {
                    Console.WriteLine("attractionsMap is null");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing AttractionsPage: {ex}");
                throw;
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
