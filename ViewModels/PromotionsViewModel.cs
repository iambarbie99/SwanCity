using SwanCity.Models;
using SwanCity.Services;
using System.Collections.ObjectModel;

namespace SwanCity.ViewModels
{
    public class PromotionsViewModel
    {
        private readonly PromotionService _promotionService;

        public ObservableCollection<Promotion> Promotions { get; }

        public PromotionsViewModel()
        {
            _promotionService = new PromotionService();
            Promotions = _promotionService.GetActivePromotions();
        }
    }
}
