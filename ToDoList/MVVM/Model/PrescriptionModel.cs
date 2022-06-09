using System.ComponentModel.DataAnnotations;
using ServiceStack.DataAnnotations;
using ToDoList.Core;

namespace ToDoList.MVVM.Model
{
    internal class PrescriptionModel : BaseViewModel
    {
        [Key]
        public int PrescriptionId { get; set; }

        public string DrugName { get; set; }

        public string DrugDescription { get; set; }

        public int DoctorId { get; set; }

        public int PatientId { get; set; }

        public bool IsSelected { get; set; }
    }
}
 