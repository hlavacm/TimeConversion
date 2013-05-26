using Netcorex.TimeConversion.Models;

namespace Netcorex.TimeConversion.Views
{
  /// <summary>
  /// The View for the total time counts
  /// </summary>
  public partial class TimeCountView
  {
    public TimeCountView()
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
