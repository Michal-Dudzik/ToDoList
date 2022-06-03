namespace ToDoList
{
     class MainViewModel : BaseViewModel
    {

        public RelayCommand MainViewCommand { get; set; }
        public RelayCommand PatientViewCommand { get; set; }
        public RelayCommand DoctorViewCommand { get; set; }
        public RelayCommand AppointmentViewCommand { get; set; }
        public RelayCommand PrescriptionViewCommand { get; set; }


        public MainViewModel MainVM { get; set; }
        public PatientsViewModel PatientVM { get; set; }
        public DoctorsViewModel DoctorsVM { get; set; }
        public AppointmentsViewModel AppointmentVM { get; set; }
        public PrescriptionViewModel PrescriptionVM { get; set; }

        private object _currentView;

        public object CurrentView
        { 
            get { return _currentView; } 
            set { 
                _currentView = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel()
        {
            PatientVM = new PatientsViewModel();
            DoctorsVM = new DoctorsViewModel();
            AppointmentVM = new AppointmentsViewModel();
            PrescriptionVM = new PrescriptionViewModel();

            CurrentView = PatientVM;

            PatientViewCommand = new RelayCommand(o =>
            {
                CurrentView = PatientVM;
            });

            DoctorViewCommand = new RelayCommand(o =>
            {
                CurrentView = DoctorsVM;
            });

            AppointmentViewCommand = new RelayCommand(o =>
            {
                CurrentView = AppointmentVM;
            });

            PrescriptionViewCommand = new RelayCommand(o =>
            {
                CurrentView = PrescriptionVM;
            });
        }
    }
}
