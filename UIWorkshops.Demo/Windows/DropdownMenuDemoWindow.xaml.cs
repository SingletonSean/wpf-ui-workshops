using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace UIWorkshops.Demos.Windows
{
    /// <summary>
    /// Interaction logic for DropdownMenuDemoWindow.xaml
    /// </summary>
    public partial class DropdownMenuDemoWindow : Window
    {
        public ObservableCollection<PeopleViewModel> PeopleViewModels { get; }

        public DropdownMenuDemoWindow()
        {
            InitializeComponent();

            DataContext = this;
            PeopleViewModels = new ObservableCollection<PeopleViewModel>()
            {
                new PeopleViewModel()
                {
                     Name = "Freelancer RG",
                     PeopleActionViewModels = new ObservableCollection<PeopleActionViewModel>()
                     {
                         new PeopleActionViewModel() { Title = "Add" },
                         new PeopleActionViewModel() { Title = "Edit" },
                         new PeopleActionViewModel() { Title = "Delete" }
                     }
                }
            };
        }
    }

    public class PeopleViewModel
    {
        public string Name { get; set; }
        public ObservableCollection<PeopleActionViewModel> PeopleActionViewModels { get; set; }
    }

    public class PeopleActionViewModel
    {
        public string Title { get; set; }
    }
}
