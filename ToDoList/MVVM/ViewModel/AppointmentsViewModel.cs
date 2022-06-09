using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using ToDoList.Core;
using ToDoList.MVVM.Controls;
using ToDoList.MVVM.Model;

namespace ToDoList.MVVM.ViewModel
{
    internal class AppointmentsViewModel :BaseViewModel
    {
        public ObservableCollection<AppointmentsModel> AppointmentLists { get; set; } = new ObservableCollection<AppointmentsModel>();
        
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public int AppointmentId { get; set; }
        public DateTime DateOfAppointment { get; set; }
        public status Status { get; set; }
        
        public ICommand AddNewAppointmentCommand { get; set; }
        public ICommand DeleteAppointmentCommand { get; set; }
        
        public AppointmentsViewModel()
        {
            AddNewAppointmentCommand = new RelayCommand(AddNewAppointment);
            DeleteAppointmentCommand = new RelayCommand(DeleteAppointment);

            foreach (var meeting in DataBaseLocator.DataBase.AppointmentsTable.ToList())
            {
                AppointmentLists.Add(new AppointmentsModel()
                {
                    AppointmentId = meeting.AppointmentId,
                    DoctorId = meeting.DoctorId,
                    PatientId = meeting.PatientId,
                    DateOfAppointment = meeting.DateOfAppointment,
                });
            }
        }
        
        private void AddNewAppointment(object obj)
        {
            var appointment = new AppointmentsModel()
            {
                AppointmentId = AppointmentId,
                DoctorId = DoctorId,
                PatientId = PatientId,
                DateOfAppointment = DateOfAppointment,
                Status = Status
            };
            AppointmentLists.Add(appointment);
        
            DataBaseLocator.DataBase.AppointmentsTable.Add(appointment);
        public enum status
        {
            Pending,
            Confirmed,
            Cancelled
        }
    }
}
