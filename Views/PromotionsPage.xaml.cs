using SwanCity.ViewModels;

namespace SwanCity.Views
{
    public partial class PromotionsPage : ContentPage
    {
        public PromotionsPage()
        {
            InitializeComponent();
            BindingContext = new PromotionsViewModel();
        }
    }
}
