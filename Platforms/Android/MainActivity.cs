﻿using Android.App;
using Android.Content.PM;
using Android.OS;

namespace SwanCity
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);
            }
            catch (Exception ex)
            {
                Android.Util.Log.Error("MAUI_CRASH", $"Application crashed: {ex}");
                throw;
            }
        }
    }
}