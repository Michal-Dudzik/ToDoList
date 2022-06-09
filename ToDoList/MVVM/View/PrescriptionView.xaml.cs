using System.Windows.Controls;

namespace ToDoList.MVVM.View
{
    public partial class PrescriptionView : UserControl
    {
        public PrescriptionView()
        {
            InitializeComponent();
            DataContext = new PrescriptionView();
        }
    }
}