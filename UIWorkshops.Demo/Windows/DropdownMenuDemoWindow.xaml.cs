using System.Collections.Generic;
using System.Windows;

namespace UIWorkshops.Demos.Windows
{
    /// <summary>
    /// Interaction logic for DropdownMenuDemoWindow.xaml
    /// </summary>
    public partial class DropdownMenuDemoWindow : Window
    {
        public DropdownMenuDemoWindow()
        {
            InitializeComponent();

            lvNames.ItemsSource = new List<string>()
            {
                "Joe",
                "Sean",
                "Mary"
            };
        }

        private void OnEditClick(object sender, RoutedEventArgs e)
        {

        }

        private void OnDeleteClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
