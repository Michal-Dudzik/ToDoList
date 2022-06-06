using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using ToDoList.Core;
using ToDoList.MVVM.Model;

namespace ToDoList.MVVM.ViewModel
{
    internal class PatientsViewModel : BaseViewModel
    {
        public ObservableCollection<PatientModel> PatientList { get; set; } = new ObservableCollection<PatientModel>();

        public string NewPatientFirstName { get; set; }
        public string NewPatientLastName { get; set; }
        public int NewPesel { get; set; }
        public DateTime NewDateOfBirth { get; set; }
        public int NewPatientContactNumber { get; set; }

        public ICommand AddNewPatientCommand { get; set; }
        public ICommand DeleteSelectedPatientCommand { get; set; }
        
        public PatientsViewModel()
        {
            AddNewPatientCommand = new RelayCommand(AddNewPatient);
            DeleteSelectedPatientCommand = new RelayCommand(DeleteSelectedPatient);

            foreach (var patient in DataBaseLocator.DataBase.PatientTable.ToList())
            {
                PatientList.Add(new PatientModel
                {
                    PatientFirstName = patient.PatientFirstName,
                    PatientLastName = patient.PatientLastName,
                    Pesel = patient.Pesel,
                    DateOfBirth = patient.DateOfBirth,
                    PatientContactNumber = patient.PatientContactNumber,
                });

            }
        }
        private void AddNewPatient()
        {
            var newPatient = new PatientModel
            {
                PatientFirstName = NewPatientFirstName,
                PatientLastName = NewPatientLastName,
                Pesel = NewPesel,
                DateOfBirth = NewDateOfBirth,
                PatientContactNumber = NewPatientContactNumber,
            };

            PatientList.Add(newPatient);

            DataBaseLocator.DataBase.PatientTable.Add(new PatientModel
            {
                PatientFirstName = newPatient.PatientFirstName,
                PatientLastName = newPatient.PatientLastName,
                Pesel = newPatient.Pesel,
                DateOfBirth = newPatient.DateOfBirth,
                PatientContactNumber = newPatient.PatientContactNumber,
            });
            
            DataBaseLocator.DataBase.SaveChanges();

            NewPatientFirstName = string.Empty;
            NewPatientLastName = string.Empty;
            NewPesel = 0;
            NewPatientContactNumber = 0;
            NewDateOfBirth = DateTime.Now;

        }

        private void DeleteSelectedPatient()
        {
            var selectedPatients = PatientList.Where(x => x.IsSelected).ToList();

            foreach (var patient in selectedPatients)
            {
                PatientList.Remove(patient);

                var foundEntity = DataBaseLocator.DataBase.PatientTable.FirstOrDefault(x=>x.PatientId==patient.PatientId);

                if(foundEntity!=null)
                {
                    DataBaseLocator.DataBase.PatientTable.Remove(foundEntity);
                }
            }
            DataBaseLocator.DataBase.SaveChanges();
        }
    }
}

