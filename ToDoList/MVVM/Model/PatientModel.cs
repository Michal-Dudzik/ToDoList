using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.DataAnnotations;
using ToDoList.Core;

namespace ToDoList.MVVM.Model
{
    internal class PatientModel :BaseViewModel
    {
        [Key][AutoIncrement]
        public int PatientId { get; set; }

        public string PatientFirstName { get; set; }

        public string PatientLastName { get; set; }

        public double Pesel { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int PatientContactNumber { get; set; }

        public bool IsSelected { get; set; }
    }
}
