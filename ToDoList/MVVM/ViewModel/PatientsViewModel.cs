using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Core;

namespace ToDoList.MVVM.ViewModel
{
    internal class PatientsViewModel : BaseViewModel
    {
        public List<PatientModel> PatientList { get; set; } = new List<PatientModel>();

        public string NewPatientFirstName { get; set; }
        public string NewPatientLasttName { get; set; }
        public int NewPesel { get; set; }
        public DateTime NewDateOfBirth { get; set; }
        public int NewPatientContactNumber { get; set; }

        public ICommand AddNewPatientCommand { get; set; }
        public ICommand DeleteSelectedPatientCommand { get; set; }
        
        public PatientsViewModel()
        {
            AddNewPatientCommand = new RelayCommand(AddNewPatient);
            DeleteSelectedPatientCommand = new RelayCommand(DeleteSelectedPatient);
        }
        private void AddNewPatient()
        {
            var newPatient = new PatientModel
            {
                PatientFirstName = NewPatientFirstName,
                PatientLastName = NewPatientLasttName,
                Pesel = NewPesel,
                DateOfBirth = NewDateOfBirth,
                PatientContactNumber = NewPatientContactNumber,
            };

            PatientList.Add(newPatient);

            NewPatientFirstName = string.Empty;
            NewPatientLasttName = string.Empty;
            NewPesel = 0;
            NewPatientContactNumber = 0;
            NewDateOfBirth = DateTime.Now;

        }

        private void DeleteSelectedPatient()
        {
            var selectedTasks = PatientList.Where(x => x.IsSelected).ToList();

            foreach (var task in selectedTasks)
            {
                PatientList.Remove(task);
            }
        }
    }
}

