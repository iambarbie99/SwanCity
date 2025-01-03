using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace SwanCity.Converters
{
    public class RatingToIndexConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is int rating)
            {
                return rating - 1; // Convert rating (1-5) to index (0-4)
            }
            return 0;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is int index)
            {
                return index + 1; // Convert index (0-4) to rating (1-5)
            }
            return 1;
        }
    }
}
