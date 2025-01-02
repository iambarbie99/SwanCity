using Plugin.LocalNotification;
using SwanCity.Models;
using System;
using System.Threading.Tasks;

namespace SwanCity.Services
{
    public class NotificationService
    {
        private int _notificationId = 100;

        public NotificationService()
        {
            LocalNotificationCenter.Current.NotificationActionTapped += OnNotificationTapped;
        }

        public async Task ShowNotification(string? title, string? message)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(message))
            {
                throw new ArgumentException("Title and message cannot be null or empty");
            }

            var notification = new NotificationRequest
            {
                NotificationId = _notificationId++,
                Title = title,
                Description = message,
                ReturningData = "Dummy data",
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(5)
                }
            };

            await LocalNotificationCenter.Current.Show(notification);
        }

        public async Task NotifyNewAttraction(TouristAttraction? attraction)
        {
            if (attraction == null || string.IsNullOrEmpty(attraction.Name))
            {
                throw new ArgumentException("Attraction cannot be null and must have a name");
            }

            await ShowNotification("New Attraction Added!",
                $"Check out the new {attraction.Name} in SwanCity!");
        }

        public async Task NotifyPromotion(string? promotionTitle)
        {
            if (string.IsNullOrEmpty(promotionTitle))
            {
                throw new ArgumentException("Promotion title cannot be null or empty");
            }

            await ShowNotification("Special Promotion!",
                $"{promotionTitle} - Limited time offer!");
        }

        public async Task NotifyTripReminder(string tripName, DateTime reminderTime)
        {
            var notification = new NotificationRequest
            {
                NotificationId = _notificationId++,
                Title = "Trip Reminder",
                Description = $"Don't forget about your {tripName} trip!",
                ReturningData = tripName,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = reminderTime
                }
            };

            await LocalNotificationCenter.Current.Show(notification);
        }

        public async Task NotifyPackageBooked(TripPackage package)
        {
            var notification = new NotificationRequest
            {
                NotificationId = _notificationId++,
                Title = "Booking Confirmation",
                Description = $"Your booking for '{package.Name}' is confirmed!",
                ReturningData = package.Id,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(5)
                }
            };

            await LocalNotificationCenter.Current.Show(notification);
        }

        private void OnNotificationTapped(Plugin.LocalNotification.EventArgs.NotificationActionEventArgs e)
        {
            // Handle notification tap
            if (e.Request.ReturningData is string data)
            {
                // Handle notification data
            }
        }
    }
}
