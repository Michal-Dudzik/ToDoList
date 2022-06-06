using System.Windows.Controls;
using ToDoList.MVVM.ViewModel;

namespace ToDoList.MVVM.View
{
    public partial class PatientsView : UserControl
    {
        public PatientsView()
        {
            InitializeComponent();
            DataContext = new PatientsViewModel();
        }
    }
}