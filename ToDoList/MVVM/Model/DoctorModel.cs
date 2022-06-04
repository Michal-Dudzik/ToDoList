using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Core;

namespace ToDoList
{
    internal class DoctorModel :BaseViewModel
    {
        public bool IsSelected { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }
        public int ContactNumber { get; set; }
        public string Status { get; set; }
    }
}
