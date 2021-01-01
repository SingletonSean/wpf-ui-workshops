using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UIWorkshops.Demos.Windows
{
    /// <summary>
    /// Interaction logic for HoldSubmitButtonDemoWindow.xaml
    /// </summary>
    public partial class HoldSubmitButtonDemoWindow : Window
    {
        public HoldSubmitButtonDemoWindow()
        {
            InitializeComponent();
        }

        private void HoldSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Thanks for holding me.");
        }
    }
}
