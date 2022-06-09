using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;
using ToDoList.Core;
using ToDoList.MVVM.Model;

namespace ToDoList.MVVM.ViewModel
{
    internal class PrescriptionViewModel : BaseViewModel
    {
        public ObservableCollection<PrescriptionModel> PrescriptionList { get; set; } = new ObservableCollection<PrescriptionModel>();

        public int NewPrescriptionId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public string NewDrugName { get; set; }
        public string NewDrugDescription { get; set; }

        public ICommand AddPrescriptionCommand { get; set; }
        public ICommand DeletePrescriptionCommand { get; set; }
        public ICommand UpdatePrescriptionCommand {get; set;}

        public PrescriptionViewModel()
        {
            AddPrescriptionCommand = new RelayCommand(AddPrescription);
            DeletePrescriptionCommand = new RelayCommand(DeletePrescription);
            UpdatePrescriptionCommand = new RelayCommand(UpdatePrescription);

            foreach (var pres in DataBaseLocator.DataBase.PrescriptionTable.ToList())
            {
                PrescriptionList.Add(new PrescriptionModel
                {
                    PrescriptionId = pres.PrescriptionId,
                    DoctorId = pres.DoctorId,
                    PatientId = pres.PatientId,
                    DrugName = pres.DrugName,
                    DrugDescription = pres.DrugDescription
                });
            }
        }
        
        private void AddPrescription()
        {
            if (string.IsNullOrEmpty(NewDrugName) || string.IsNullOrEmpty(NewDrugDescription))
            {
                MessageBox.Show("Wypełnij wszystkie pola");
                return;
            }
            
            var newPrescription = new PrescriptionModel()
            {
                PrescriptionId = NewPrescriptionId,
                DoctorId = DoctorId,
                PatientId = PatientId,
                DrugName = NewDrugName,
                DrugDescription = NewDrugDescription
            };
            
            PrescriptionList.Add(newPrescription);
            
            DataBaseLocator.DataBase.PrescriptionTable.Add(new PrescriptionModel
            {
                PrescriptionId = newPrescription.PrescriptionId,
                DoctorId = newPrescription.DoctorId,
                PatientId = newPrescription.PatientId,
                DrugName = newPrescription.DrugName,
                DrugDescription = newPrescription.DrugDescription
            });
            
            DataBaseLocator.DataBase.SaveChanges();
            
            NewDrugName = string.Empty;
            NewDrugDescription = string.Empty;
        }

        private void DeletePrescription()
        {
            var prescriptionId = PrescriptionList.FirstOrDefault(x => x.IsSelected).PrescriptionId;
            DataBaseLocator.DataBase.PrescriptionTable.Remove(DataBaseLocator.DataBase.PrescriptionTable.FirstOrDefault(x => x.PrescriptionId == prescriptionId));
            PrescriptionList.Remove(PrescriptionList.FirstOrDefault(x => x.IsSelected));
            DataBaseLocator.DataBase.SaveChanges();
        }

        private void UpdatePrescription()
        {
            DataBaseLocator.DataBase.SaveChanges();
        }
        
        public Array DoctorArray
        {
            get
            {
                var doctors = DataBaseLocator.DataBase.DoctorTable.ToList();
                var doctorArray = new string[doctors.Count];
                for (int i = 0; i < doctors.Count; i++)
                {
                    doctorArray[i] = doctors[i].DoctorFirstName + " " + doctors[i].DoctorLastName;
                }
                return doctorArray;
            }
        }
        public Array PatientArray
        {
            get
            {
                var patients = DataBaseLocator.DataBase.PatientTable.ToList();
                var patientArray = new string[patients.Count];
                for (int i = 0; i < patients.Count; i++)
                {
                    patientArray[i] = patients[i].PatientFirstName + " " + patients[i].PatientLastName;
                }
                return patientArray;
            }
        }
    }
}
