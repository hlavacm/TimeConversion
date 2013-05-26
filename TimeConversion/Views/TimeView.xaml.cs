using Netcorex.TimeConversion.Models;

namespace Netcorex.TimeConversion.Views
{
  /// <summary>
  /// The View for the time edit
  /// </summary>
  public partial class TimeView
  {
    public TimeView()
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
