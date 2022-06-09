using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;
using ToDoList.Core;
using ToDoList.MVVM.Model;

namespace ToDoList.MVVM.ViewModel
{ 
    public class DoctorsViewModel: BaseViewModel
    {
            public ObservableCollection<DoctorModel> DoctorList { get; set; } = new ObservableCollection<DoctorModel>();
            
            public string NewDoctorFirstName { get; set; }
            public string NewDoctorLastName { get; set; }
            public string NewSpecialization { get; set; }
            public int NewDoctorContactNumber { get; set; }
            

            public ICommand AddNewDoctorCommand { get; }
            public ICommand DeleteSelectedDoctorCommand { get; }
            
            public DoctorsViewModel()
            {
            AddNewDoctorCommand = new RelayCommand(AddNewDoctor);
            DeleteSelectedDoctorCommand = new RelayCommand(DeleteSelectedDoctor);

            foreach (var doctor in DataBaseLocator.DataBase.DoctorTable.ToList())
            {
                DoctorList.Add(new DoctorModel
                {
                    DoctorId = doctor.DoctorId,
                    DoctorFirstName = doctor.DoctorFirstName,
                    DoctorLastName = doctor.DoctorLastName,
                    Specialization = doctor.Specialization,
                    DoctorContactNumber = doctor.DoctorContactNumber,
                });
            }
            }
            
            private void AddNewDoctor()
            {
                //fields cannot be empty
                if (NewDoctorFirstName == "" || NewDoctorLastName == "" || NewSpecialization == "" || NewDoctorContactNumber == 0)
                {
                    MessageBox.Show("Wypełnij wszystkie pola");
                    return;
                }

                var newDoctor = new DoctorModel
                {
                    DoctorFirstName = NewDoctorFirstName,
                    DoctorLastName = NewDoctorLastName,
                    Specialization = NewSpecialization,
                    DoctorContactNumber = NewDoctorContactNumber
                };

                DoctorList.Add(newDoctor);

                //add to database
                using (var db = new ToDoListDbContext())
                {
                    db.DoctorTable.Add(new DoctorModel()
                    {
                        DoctorFirstName = NewDoctorFirstName,
                        DoctorLastName = NewDoctorLastName,
                        Specialization = NewSpecialization,
                        DoctorContactNumber = NewDoctorContactNumber
                    });
                    db.SaveChanges();
                }
                
                NewDoctorFirstName = "";
                NewDoctorLastName = "";
                NewSpecialization = "";
                NewDoctorContactNumber = 0;
            }
            
            //delete selected doctor from database
            private void DeleteSelectedDoctor()
            {
            //get patient id from selected patient
            var doctorId = DoctorList.First(x => x.IsSelected).DoctorId;
            //delete patient from database
            DataBaseLocator.DataBase.DoctorTable.Remove(DataBaseLocator.DataBase.DoctorTable.First(x => x.DoctorId == doctorId));
            //delete patient from list
            DoctorList.Remove(DoctorList.First(x => x.IsSelected));
            //save changes
            DataBaseLocator.DataBase.SaveChanges();
        }

    }
}
