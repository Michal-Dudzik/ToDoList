using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList
{
    internal class DoctorViewModel :BaseViewModel
    {
        public bool IsSelected { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int ContactNumber { get; set; }
        public string Status { get; set; }
    }
}
