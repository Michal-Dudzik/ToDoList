using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
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
        public double NewPesel { get; set; }
        public DateTime NewDateOfBirth { get; set; } = DateTime.Now;
        public int NewPatientContactNumber { get; set; }

        public ICommand AddNewPatientCommand { get; }
        public ICommand DeleteSelectedPatientCommand { get; }
       

        public PatientsViewModel()
        {
            AddNewPatientCommand = new RelayCommand(AddNewPatient);
            DeleteSelectedPatientCommand = new RelayCommand(DeleteSelectedPatient);
            

            foreach (var patient in DataBaseLocator.DataBase.PatientTable.ToList())
            {
                PatientList.Add(new PatientModel
                {
                    PatientId = patient.PatientId,
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
            //fields cannot be empty
            if (NewPatientFirstName == "" || NewPatientLastName == "" || NewPesel == 0 || NewPatientContactNumber == 0)
            {
                MessageBox.Show("Wypełnij wszystkie pola");
                return;
            }

            //condition that pesel needs to be at least 11 digits
            if (NewPesel.ToString().Length != 11)
            {
                MessageBox.Show("Pesel mieć 11 znaków");
                return;
            }

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
            //get patient id from selected patient
            var patientId = PatientList.First(x => x.IsSelected).PatientId;
            //delete patient from database
            DataBaseLocator.DataBase.PatientTable.Remove(DataBaseLocator.DataBase.PatientTable.First(x => x.PatientId == patientId));
            //delete patient from list
            PatientList.Remove(PatientList.First(x => x.IsSelected));
            //save changes
            DataBaseLocator.DataBase.SaveChanges();
        }
        
    }
}
