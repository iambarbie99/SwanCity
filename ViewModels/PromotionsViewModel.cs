using SwanCity.Models;
using SwanCity.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Timers;

namespace SwanCity.ViewModels
{
    public class PromotionsViewModel : INotifyPropertyChanged, IDisposable
    {
        private readonly PromotionService _promotionService;
        private readonly System.Timers.Timer _refreshTimer;

        public ObservableCollection<Promotion> Promotions { get; }

        public PromotionsViewModel()
        {
            _promotionService = new PromotionService();
            Promotions = _promotionService.GetActivePromotions();
            
            // Set up timer to refresh progress every minute
            _refreshTimer = new System.Timers.Timer(60000); // 60 seconds
            _refreshTimer.Elapsed += OnTimerElapsed;
            _refreshTimer.Start();
        }

        private void OnTimerElapsed(object? sender, ElapsedEventArgs e)
        {
            // Notify UI that DaysRemaining values have changed
            foreach (var promotion in Promotions)
            {
                OnPropertyChanged(nameof(promotion.DaysRemaining));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Dispose()
        {
            _refreshTimer.Stop();
            _refreshTimer.Dispose();
        }
    }
}
