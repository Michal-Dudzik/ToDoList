using System.Windows.Controls;
using ToDoList.MVVM.ViewModel;
namespace ToDoList.MVVM.View
{
    public partial class DoctorsView : UserControl
    {
        public DoctorsView()
        {
            InitializeComponent();
            DataContext = new DoctorsViewModel();
        }
    }
}
