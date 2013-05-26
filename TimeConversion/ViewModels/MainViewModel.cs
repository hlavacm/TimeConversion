using System.Text;
using System.Windows;
using System.Windows.Input;
using Netcorex.Shared.WPF.Common;
using Netcorex.Shared.WPF.Helpers;
using Netcorex.Shared.WPF.ViewModels;
using Netcorex.TimeConversion.Localization;
using Netcorex.TimeConversion.Models;

namespace Netcorex.TimeConversion.ViewModels
{
  /// <summary>
  /// ViewModel for the Main Window
  /// </summary>
  public class MainViewModel : ViewModelBase<TimeModel>
  {
    public MainViewModel()
      : base(new TimeModel())
    {
      AboutCommand = new RelayCommand(AboutCommandAction);
      CopyTimeToClipboardCommand = new RelayCommand(CopyTimeToClipboardCommandAction);
    }


    public ICommand AboutCommand { get; set; }
    public ICommand CopyTimeToClipboardCommand { get; set; }


    private void AboutCommandAction(object parameter)
    {
      StringBuilder aboutBuilder = new StringBuilder();
      aboutBuilder.AppendLine(App.ProgramName);
      aboutBuilder.AppendLine(string.Format("v{0}", Features.GetVersion()));
      aboutBuilder.AppendLine("mailto:hlavacm@hotmail.com/");
      aboutBuilder.AppendLine("http://blog.netcorex.cz/");
      aboutBuilder.AppendLine(App.ProgramCopyright);
      aboutBuilder.AppendLine("---");
      aboutBuilder.AppendLine("FAMFAMFAM Silk Icons");
      aboutBuilder.AppendLine("www.famfamfam.com/lab/icons/silk");
      MessageBox.Show(aboutBuilder.ToString(), Titles.About, MessageBoxButton.OK, MessageBoxImage.Information);
    }

    private void CopyTimeToClipboardCommandAction(object parameter)
    {
      Clipboard.SetText(Model.Text);
    }
  }
}
