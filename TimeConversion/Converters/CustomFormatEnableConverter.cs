using System;
using System.Globalization;
using System.Windows.Data;
using Netcorex.TimeConversion.Enums;
using Netcorex.TimeConversion.Structs;

namespace Netcorex.TimeConversion.Converters
{
  /// <summary>
  /// One-way converter for enabling by comparing the value ​​with <see cref="TimeFormats.Custom"/>
  /// </summary>
  public class CustomFormatEnableConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      TimeFormat format = (TimeFormat)value;
      return format.Key == TimeFormats.Custom;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
