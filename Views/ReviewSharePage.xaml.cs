using SwanCity.ViewModels;

namespace SwanCity.Views
{
    public partial class ReviewSharePage : ContentPage
    {
        public ReviewSharePage(ReviewShareViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
