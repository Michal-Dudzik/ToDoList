using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.DataAnnotations;
using ToDoList.Core;

namespace ToDoList.MVVM.Model
{
    internal class AppointmentsModel :BaseViewModel
    {

        [Key]
        public int AppointmentId { get; set; }
        
        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime DateOfAppointment { get; set; }

        public string Status { get; set; }

        public bool IsSelected { get; set; }
    }
}
