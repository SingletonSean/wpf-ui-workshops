using System.Windows;

namespace UIWorkshops.Demos
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new Window();
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
