using ToDoList.Core;

namespace ToDoList.MVVM.ViewModel
{
     class MainViewModel : BaseViewModel
    {
        public RelayCommand PatientViewCommand { get; set; }
        public RelayCommand DoctorViewCommand { get; set; }
        public RelayCommand AppointmentViewCommand { get; set; }
        public RelayCommand PrescriptionViewCommand { get; set; }
        
        public PatientsViewModel PatientVm { get; set; }
        public DoctorsViewModel DoctorsVm { get; set; }
        public AppointmentsViewModel AppointmentVm { get; set; }
        public PrescriptionViewModel PrescriptionVm { get; set; }

        private object _currentView;
        public object CurrentView
        { 
            get => _currentView;
            set { 
                _currentView = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel()
        {
            PatientVm = new PatientsViewModel();
            DoctorsVm = new DoctorsViewModel();
            AppointmentVm = new AppointmentsViewModel();
            PrescriptionVm = new PrescriptionViewModel();
        
            CurrentView = PatientVm;
            
            PatientViewCommand = new RelayCommand(() => CurrentView = PatientVm);
            DoctorViewCommand = new RelayCommand(() => CurrentView = DoctorsVm);
            AppointmentViewCommand = new RelayCommand(() => CurrentView = AppointmentVm);
            PrescriptionViewCommand = new RelayCommand(() => CurrentView = PrescriptionVm);
        }
    }
}
