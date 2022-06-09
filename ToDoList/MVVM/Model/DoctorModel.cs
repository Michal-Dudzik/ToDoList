using System.ComponentModel.DataAnnotations;
using ServiceStack.DataAnnotations;
using ToDoList.Core;

namespace ToDoList.MVVM.Model
{
    public class DoctorModel :BaseViewModel
    {
        [Key]
        public int DoctorId { get; set; }

        public string DoctorFirstName { get; set; }

        public string DoctorLastName { get; set; }

        public string Specialization { get; set; }

        public int DoctorContactNumber { get; set; }

        public bool IsSelected { get; set; }
    }
}
