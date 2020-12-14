using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class HighlightTextBlockDemoWindow : Window
    {
        public HighlightTextBlockDemoWindow()
        {
            InitializeComponent();

            lvItems.ItemsSource = new ObservableCollection<string>()
            {
                "Hello world!",
                "My name is",
                "SingletonSean",
                "and my cat",
                "is meowing at me while I write this."
            };
        }
    }
}
