using System.Windows.Input;
using Netcorex.TimeConversion.Properties;
using Netcorex.TimeConversion.ViewModels;

namespace Netcorex.TimeConversion
{
  /// <summary>
  /// The Main (startup) Window
  /// </summary>
  public partial class MainWindow
  {
    public MainWindow()
      : base(250, 420, 250, 420)
    {
      InitializeComponent();
      DataContext = new MainViewModel();
      InputBindings.Add(new KeyBinding(DataContext.AboutCommand, new KeyGesture(Key.F1)));
      InputBindings.Add(new KeyBinding(DataContext.CopyTimeToClipboardCommand, new KeyGesture(Key.C, ModifierKeys.Control)));
    }


    public new MainViewModel DataContext
    {
      get { return base.DataContext as MainViewModel; }
      set { base.DataContext = value; }
    }


    protected override void SaveSettings()
    {
      Settings.Default.Save();
    }
  }
}
