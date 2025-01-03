using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace SwanCity.ViewModels
{
    public partial class ReviewShareViewModel : ObservableObject
    {
        [ObservableProperty]
        private string reviewTitle = string.Empty;

        [ObservableProperty]
        private string reviewText = string.Empty;

        [ObservableProperty]
        private int selectedRating = 3;

        public ObservableCollection<int> RatingOptions { get; } = new() { 1, 2, 3, 4, 5 };

        [RelayCommand]
        private void ShareReview()
        {
            // Frontend-only implementation
            // Show confirmation message
            Application.Current.MainPage.DisplayAlert(
                "Review Shared", 
                "Thank you for sharing your review!", 
                "OK");
        }
    }
}
