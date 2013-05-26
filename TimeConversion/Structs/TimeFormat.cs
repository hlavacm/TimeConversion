using System;
using Netcorex.TimeConversion.Enums;

namespace Netcorex.TimeConversion.Structs
{
  /// <summary>
  /// Structure allowing to select the time format (it is useful for ComboBox)
  /// </summary>
  public struct TimeFormat
  {
    private readonly TimeFormats _key;
    private readonly string _title;
    private readonly string _value;


    public TimeFormat(TimeFormats key, string title, string value)
    {
      if (key == TimeFormats.None)
      {
        throw new ArgumentNullException("key");
      }
      if (string.IsNullOrEmpty(title))
      {
        throw new ArgumentNullException("title");
      }
      _key = key;
      _title = title;
      _value = value;
    }


    public TimeFormats Key
    {
      get { return _key; }
    }
    public string Title
    {
      get { return _title; }
    }
    public string Value
    {
      get { return _value; }
    }
  }
}
