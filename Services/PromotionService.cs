using SwanCity.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace SwanCity.Services
{
    public class PromotionService
    {
        private readonly List<Promotion> _promotions = new()
        {
            new Promotion
            {
                Id = "1",
                Title = "Summer Special",
                Description = "Get 20% off all Swan River Cruises",
                ImageUrl = "summer_special.jpg",
                ValidUntil = DateTime.Now.AddDays(30)
            },
            new Promotion
            {
                Id = "2",
                Title = "Family Fun Package",
                Description = "Buy 2 adult tickets, get 1 child ticket free for all attractions",
                ImageUrl = "family_fun.jpg",
                ValidUntil = DateTime.Now.AddDays(45)
            },
            new Promotion
            {
                Id = "3",
                Title = "Weekend Getaway",
                Description = "25% off all weekend hotel stays and attraction packages",
                ImageUrl = "weekend_getaway.jpg",
                ValidUntil = DateTime.Now.AddDays(60)
            },
            new Promotion
            {
                Id = "4",
                Title = "Early Bird Special",
                Description = "15% off all bookings made before 9 AM",
                ImageUrl = "early_bird.jpg",
                ValidUntil = DateTime.Now.AddDays(90)
            },
            new Promotion
            {
                Id = "5",
                Title = "Group Discount",
                Description = "10% off for groups of 5 or more",
                ImageUrl = "group_discount.jpg",
                ValidUntil = DateTime.Now.AddDays(120)
            }
        };

        public ObservableCollection<Promotion> GetActivePromotions()
        {
            return new ObservableCollection<Promotion>(
                _promotions.Where(p => p.ValidUntil > DateTime.Now));
        }
    }
}
