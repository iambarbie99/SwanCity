using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace SwanCity.Converters
{
    /// <summary>
    /// Converts null values to boolean, with optional inversion
    /// </summary>
    public class NullToBoolConverter : IValueConverter
    {
        /// <summary>
        /// Converts a value to boolean based on null check
        /// </summary>
        /// <param name="value">The value to check</param>
        /// <param name="targetType">The target type (bool)</param>
        /// <param name="parameter">Optional parameter to invert the result ("true" to invert)</param>
        /// <param name="culture">Culture info</param>
        /// <returns>True if value is not null, false if null (or inverted based on parameter)</returns>
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            try
            {
                bool result = value != null;
                
                // Handle inversion parameter
                if (parameter is string paramStr && 
                    bool.TryParse(paramStr, out bool shouldInvert) && 
                    shouldInvert)
                {
                    return !result;
                }
                
                return result;
            }
            catch
            {
                // Return false if any error occurs
                return false;
            }
        }

        /// <summary>
        /// Not implemented as this is a one-way converter
        /// </summary>
        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
