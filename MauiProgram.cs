﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.Logging;
using SwanCity.Services;
using SwanCity.Converters;

namespace SwanCity
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiMaps()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Register services
            builder.Services.AddSingleton<AuthenticationService>();
            builder.Services.AddSingleton<AttractionService>();
            builder.Services.AddSingleton<NotificationService>();
            builder.Services.AddSingleton<ProfileService>();
            builder.Services.AddSingleton<PromotionService>();
            builder.Services.AddSingleton<TripPlannerService>();

            // Register view models
            builder.Services.AddTransient<ViewModels.LoginViewModel>();
            builder.Services.AddTransient<ViewModels.AttractionsViewModel>();
            builder.Services.AddTransient<ViewModels.ProfileViewModel>();
            builder.Services.AddTransient<ViewModels.PromotionsViewModel>();
            builder.Services.AddTransient<ViewModels.TripPlannerViewModel>();
            builder.Services.AddTransient<ViewModels.ReviewShareViewModel>();
            builder.Services.AddTransient<ViewModels.AdvertisingCornerViewModel>();
            builder.Services.AddTransient<ViewModels.WeatherViewModel>();

            // Register pages
            builder.Services.AddTransient<Views.LoginPage>();
            builder.Services.AddTransient<Views.AttractionsPage>();
            builder.Services.AddTransient<Views.ProfilePage>();
            builder.Services.AddTransient<Views.PromotionsPage>();
            builder.Services.AddTransient<Views.TripPlannerPage>();
            builder.Services.AddTransient<Views.ReviewSharePage>();
            builder.Services.AddTransient<Views.AdvertisingCornerPage>();
            builder.Services.AddTransient<Views.WeatherPage>();

            // Register converters
            builder.Services.AddSingleton<RatingToIndexConverter>();

            // Register AppShell and its dependencies
            builder.Services.AddSingleton<AppShell>();
            builder.Services.AddSingleton<App>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
