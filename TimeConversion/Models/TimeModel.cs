using System;
using System.Collections.Generic;
using System.Linq;
using Netcorex.Shared.WPF.Models;
using Netcorex.TimeConversion.Enums;
using Netcorex.TimeConversion.Localization;
using Netcorex.TimeConversion.Properties;
using Netcorex.TimeConversion.Structs;

namespace Netcorex.TimeConversion.Models
{
  /// <summary>
  /// Model for the definition and operation with Time (TimeSpan)
  /// </summary>
  public class TimeModel : ModelBase
  {
    public int TotalRoundDigits = 3;
    private TimeSpan _value;
    private TimeFormat _format;
    private readonly List<TimeFormat> _timeFormats;
    private string _customPattern;
    private string _text;


    public TimeModel()
    {
      _value = Settings.Default.Value;
      _timeFormats = new List<TimeFormat>
        {
          new TimeFormat(TimeFormats.Constant, Titles.ConstantInvariant, "c"),
          new TimeFormat(TimeFormats.GeneralShort, Titles.GeneralShort, "g"),
          new TimeFormat(TimeFormats.GeneralLong, Titles.GeneralLong, "G"),
          new TimeFormat(TimeFormats.Custom, Titles.Custom, null),
        };
      _format = _timeFormats.SingleOrDefault(x => x.Key == Settings.Default.FormatKey);
      _customPattern = @Settings.Default.CustomPattern;
      UpdateText();
    }


    public TimeSpan Value
    {
      get { return _value; }
      set
      {
        bool result = SetProperty(ref _value, value);
        if (result)
        {
          OnPropertyChanged("Days");
          OnPropertyChanged("Hours");
          OnPropertyChanged("Minutes");
          OnPropertyChanged("Seconds");
          OnPropertyChanged("Milliseconds");
          OnPropertyChanged("TotalYears");
          OnPropertyChanged("TotalWeeks");
          OnPropertyChanged("TotalDays");
          OnPropertyChanged("TotalHours");
          OnPropertyChanged("TotalMinutes");
          OnPropertyChanged("TotalSeconds");
          OnPropertyChanged("TotalMilliseconds");
          UpdateText();
          Settings.Default.Value = _value;
        }
      }
    }
    public List<TimeFormat> Formats
    {
      get { return _timeFormats; }
    }
    public TimeFormat Format
    {
      get { return _format; }
      set
      {
        bool result = SetProperty(ref _format, value);
        if (result)
        {
          UpdateText();
          Settings.Default.FormatKey = _format.Key;
        }
      }
    }
    public string CustomPattern
    {
      get { return _customPattern; }
      set
      {
        SetProperty(ref _customPattern, value.Trim());
        if (Format.Key == TimeFormats.Custom)
        {
          UpdateText();
          Settings.Default.CustomPattern = _customPattern;
        }
      }
    }
    public string Text
    {
      get { return _text; }
      private set { SetProperty(ref _text, value); }
    }
    public int Days
    {
      get { return Value.Days; }
      set { Value = Value.Subtract(TimeSpan.FromDays(Value.Days)).Add(TimeSpan.FromDays(value)); }
    }
    public int Hours
    {
      get { return Value.Hours; }
      set { Value = Value.Subtract(TimeSpan.FromHours(Value.Hours)).Add(TimeSpan.FromHours(value)); }
    }
    public int Minutes
    {
      get { return Value.Minutes; }
      set { Value = Value.Subtract(TimeSpan.FromMinutes(Value.Minutes)).Add(TimeSpan.FromMinutes(value)); }
    }
    public int Seconds
    {
      get { return Value.Seconds; }
      set { Value = Value.Subtract(TimeSpan.FromSeconds(Value.Seconds)).Add(TimeSpan.FromSeconds(value)); }
    }
    public int Milliseconds
    {
      get { return Value.Milliseconds; }
      set { Value = Value.Subtract(TimeSpan.FromMilliseconds(Value.Milliseconds)).Add(TimeSpan.FromMilliseconds(value)); }
    }
    public double TotalYears
    {
      get
      {
        double baseYears = Value.TotalDays / 365;
        double leapYears = baseYears / 366;
        return DefaultRoundValue(baseYears + leapYears);
      }
      set
      {
        double baseYearsDays = value * 365;
        double leapYearsDays = baseYearsDays / 366;
        Value = TimeSpan.FromDays(DefaultRoundValue(baseYearsDays + leapYearsDays));
      }
    }
    public double TotalWeeks
    {
      get { return DefaultRoundValue(Value.TotalDays / 7); }
      set { Value = TimeSpan.FromDays(DefaultRoundValue(value * 7)); }
    }
    public double TotalDays
    {
      get { return DefaultRoundValue(Value.TotalDays); }
      set { Value = TimeSpan.FromDays(DefaultRoundValue(value)); }
    }
    public double TotalHours
    {
      get { return DefaultRoundValue(Value.TotalHours); }
      set { Value = TimeSpan.FromHours(DefaultRoundValue(value)); }
    }
    public double TotalMinutes
    {
      get { return DefaultRoundValue(Value.TotalMinutes); }
      set { Value = TimeSpan.FromMinutes(DefaultRoundValue(value)); }
    }
    public double TotalSeconds
    {
      get { return DefaultRoundValue(Value.TotalSeconds); }
      set { Value = TimeSpan.FromSeconds(DefaultRoundValue(value)); }
    }
    public double TotalMilliseconds
    {
      get { return DefaultRoundValue(Value.TotalMilliseconds); }
      set { Value = TimeSpan.FromMilliseconds(DefaultRoundValue(value)); }
    }


    private void UpdateText()
    {
      TimeFormats formatKey = Format.Key;
      switch (Format.Key)
      {
        case TimeFormats.Constant:
        case TimeFormats.GeneralLong:
        case TimeFormats.GeneralShort:
          Text = Value.ToString(Format.Value);
          break;
        case TimeFormats.Custom:
          Text = Value.ToString(@CustomPattern);
          break;
        default:
          throw new NotImplementedException(string.Format("Format Key: {0}", formatKey));
      }
    }

    private double DefaultRoundValue(double value)
    {
      return Math.Round(value, TotalRoundDigits);
    }
  }
}
