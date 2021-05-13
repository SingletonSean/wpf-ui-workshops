using System.Windows;
using UIWorkshops.Demos.Windows;

namespace UIWorkshops.Demos
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new DropdownMenuDemoWindow();
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
