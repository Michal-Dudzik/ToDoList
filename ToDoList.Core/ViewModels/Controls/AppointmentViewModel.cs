using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList
{
    internal class AppointmentViewModel :BaseViewModel
    {
        public bool IsSelected { get; set; }
        public int PatientID { get; set; }
        public int DoctorId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DateOfAppointment { get; set; }
    }
}
