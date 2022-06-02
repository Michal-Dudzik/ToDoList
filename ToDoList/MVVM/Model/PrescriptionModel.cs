using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList
{
    internal class PrescriptionModel :BaseViewModel
    { 
        public string DrugName { get; set; }
        public string DrugDescription { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }

    }
}
