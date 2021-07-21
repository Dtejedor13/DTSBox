using System.Windows;

namespace DTSBox_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            this.StartupUri = new System.Uri(StartUp.GetStartUpURI(), System.UriKind.Relative);
        }
    }
}
