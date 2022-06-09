using System.Windows.Controls;
using ToDoList.MVVM.ViewModel;

namespace ToDoList.MVVM.View
{
    public partial class PrescriptionView : UserControl
    {
        public PrescriptionView()
        {
            InitializeComponent();
            DataContext = new PrescriptionViewModel();
        }
    }
}