using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;
using ToDoList.Core;
using ToDoList.MVVM.Model;

namespace ToDoList.MVVM.ViewModel
{
    internal class AppointmentsViewModel : BaseViewModel
    {
        public ObservableCollection<AppointmentsModel> AppointmentList { get; set; } = new ObservableCollection<AppointmentsModel>();
        
        public int NewDoctorId { get; set; }
        public int NewPatientId { get; set; }
        public int AppointmentId { get; set; }
        public DateTime NewDateOfAppointment { get; set; } = DateTime.Now;
        public status NewStatus { get; set; }
        
        public ICommand AddNewAppointmentCommand { get; }
        public ICommand DeleteAppointmentCommand { get; }
        
        public ICommand UpdateAppointmentCommand { get; }
        
        public AppointmentsViewModel()
        {
            AddNewAppointmentCommand = new RelayCommand(AddNewAppointment);
            DeleteAppointmentCommand = new RelayCommand(DeleteAppointment);
            UpdateAppointmentCommand = new RelayCommand(UpdateAppointment);

            foreach (var meeting in DataBaseLocator.DataBase.AppointmentsTable.ToList())
            {
                AppointmentList.Add(new AppointmentsModel()
                {
                    AppointmentId = meeting.AppointmentId,
                    DoctorId = meeting.DoctorId,
                    PatientId = meeting.PatientId,
                    DateOfAppointment = meeting.DateOfAppointment,
                });
            }
        }

        private void AddNewAppointment()
        {
            //fields cannot be empty
            if (NewDoctorId == 0 || NewPatientId == 0 || AppointmentId == 0 || NewDateOfAppointment == null ||
                NewStatus == null)
            {
                MessageBox.Show("Wypełnij wszystkie pola");
                return;
            }

            var newAppointment = new AppointmentsModel()
            {
                AppointmentId = AppointmentId,
                DoctorId = NewDoctorId,
                PatientId = NewPatientId,
                DateOfAppointment = NewDateOfAppointment,
                Status = NewStatus
            };
            AppointmentList.Add(newAppointment);

            DataBaseLocator.DataBase.AppointmentsTable.Add(new AppointmentsModel
            {
                DoctorId = newAppointment.DoctorId,
                PatientId = newAppointment.PatientId,
                AppointmentId = newAppointment.AppointmentId,
                DateOfAppointment = newAppointment.DateOfAppointment,
                Status = newAppointment.Status
            });

            DataBaseLocator.DataBase.SaveChanges();
            
            NewDoctorId = 0;
            NewPatientId = 0;
            NewDateOfAppointment = DateTime.Now;
        }

        private void DeleteAppointment()
        {
            var appointmentId = AppointmentList.FirstOrDefault(x => x.IsSelected).AppointmentId;
            DataBaseLocator.DataBase.AppointmentsTable.Remove(DataBaseLocator.DataBase.AppointmentsTable.FirstOrDefault(x => x.AppointmentId == appointmentId));
            AppointmentList.Remove(AppointmentList.FirstOrDefault(x => x.IsSelected));
            DataBaseLocator.DataBase.SaveChanges();
        }

        private void UpdateAppointment()
        {
            DataBaseLocator.DataBase.SaveChanges();
        }

        public enum status
        {
            Potwierdzone,
            Oczekuje,
            Anulowane
        }

        public Array StatusArray
        {
           get { return Enum.GetValues(typeof(status)); }
        }

        //take doctorId and return DoctorFirstName and DoctorLastName it to array of doctors
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
