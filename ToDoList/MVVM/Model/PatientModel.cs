using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList
{
    internal class PatientModel :BaseViewModel
    {
        public bool IsSelected { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public int PESEL { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int PatientContactNumber { get; set; }
    }
}
