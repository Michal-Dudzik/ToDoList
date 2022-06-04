using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Core;

namespace ToDoList
{
    internal class AppointmentsModel :BaseViewModel
    {
        public bool IsSelected { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DateOfAppointment { get; set; }
        public bool Status { get; set; }
    }
}
