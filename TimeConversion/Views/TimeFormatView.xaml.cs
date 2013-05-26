using Netcorex.TimeConversion.Models;

namespace Netcorex.TimeConversion.Views
{
  /// <summary>
  /// The View for the time string (text) format
  /// </summary>
  public partial class TimeFormatView
  {
    public TimeFormatView()
    {
      InitializeComponent();
    }


    public new TimeModel DataContext
    {
      get { return base.DataContext as TimeModel; }
      set { base.DataContext = value; }
    }
  }
}
