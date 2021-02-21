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
    public partial class ModalDemoWindow : Window
    {
        public ModalDemoWindow()
        {
            InitializeComponent();
        }

        private void OnShowModalClick(object sender, RoutedEventArgs e)
        {
            modal.IsOpen = true;
        }

        private void OnCloseModalClick(object sender, RoutedEventArgs e)
        {
            modal.IsOpen = false;
        }
    }
}
