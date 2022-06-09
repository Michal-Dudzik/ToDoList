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
            

            public ICommand AddNewPatientCommand { get; }
            public ICommand DeleteSelectedPatientCommand { get; }
            
            public DoctorsViewModel()
            {
                AddNewPatientCommand = new RelayCommand(AddNewDoctor);
                DeleteSelectedPatientCommand = new RelayCommand(DeleteSelectedDoctor);
            }
            
            private void AddNewDoctor()
            {
                DoctorList.Add(new DoctorModel()
                {
                    DoctorFirstName = NewDoctorFirstName,
                    DoctorLastName = NewDoctorLastName,
                    Specialization = NewSpecialization,
                    DoctorContactNumber = NewDoctorContactNumber
                });
                
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
                using (var db = new ToDoListDbContext())
                {
                    var selectedDoctor = db.DoctorTable.FirstOrDefault(x => x.DoctorId == DoctorList.FirstOrDefault(y => y.IsSelected).DoctorId);
                    db.DoctorTable.Remove(selectedDoctor);
                    db.SaveChanges();
                }
                DoctorList.Remove(DoctorList.FirstOrDefault(x => x.IsSelected));
            }

    }
}
