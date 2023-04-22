using CommonServiceLocator;
 using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using TP2_POO2.Models;
using TP2_POO2.Views;

namespace TP2_POO2.ViewModels
{
       class NewDoctorViewModel
    {
        private Models.Doctor _doctor;

        public Models.Doctor Doctor
        {
            get
            {
                if (_doctor == null)
                {
                    _doctor = new Doctor();
                }
                return _doctor;
            }
            set
            {
                _doctor = value;
            }
        }
/*        public Models.Doctor Doctor { get; set; }
*/        public ObservableCollection<string> Villes { get; set; }
        public List<Models.Doctor> doctors { get; set; }
        private Views.NewDoctorWindow _welcome;


        public NewDoctorViewModel(Views.NewDoctorWindow newdoctorwindow)
        {
            this._welcome = newdoctorwindow;

            this.Villes = new ObservableCollection<string>()
            {
            "Rimouski",
            "Lévis",
            "Quebec",
            "Montreal"
            };

            NewCompteCommand = new RelayCommand(
                   o => this.Doctor.IsValid,
                   o => this.NewCompte()
               );
            BackCommand = new RelayCommand(
                 o => this.Doctor.IsValid,
                 o => this.Back()
             );


        }
     

        public ICommand NewCompteCommand { get; private set; }
        public ICommand BackCommand { get; private set; }



        public event EventHandler RequestClose;
        private bool _isMaleSelected;
        public bool IsMaleSelected
        {
            get { return _isMaleSelected; }
            set
            {
                if (_isMaleSelected != value)
                {
                    _isMaleSelected = value;
                }
            }
        }

        private void Back()
        {
            DoctorLoginWindow doctorLoginWindow = new DoctorLoginWindow();
            doctorLoginWindow.Show(); 
            RequestClose?.Invoke(this, EventArgs.Empty);


        }
        private void NewCompte()
        {

          



            Models.Doctor doctor = new Models.Doctor();
            doctor.Nom = this.Doctor.Nom;
            doctor.Prenom = this.Doctor.Prenom;
            doctor.DateN = this.Doctor.DateN;
            doctor.Courriel = this.Doctor.Courriel;
            if (IsMaleSelected)
            {
                doctor.Genre = "Masculin";
            }
            else
            {
                doctor.Genre = "Féminin";
            }
            doctor.Ville = this.Doctor.Ville;

            TpDbContext tpDbContext = new TpDbContext();
            tpDbContext.Doctors.Add(doctor);
            tpDbContext.SaveChanges();


            MessageBox.Show("Votre compte a été créé avec succès!", "Sing up", MessageBoxButton.OK, MessageBoxImage.Warning);

            Views.DoctorLoginWindow doctorLoginWindow = new DoctorLoginWindow();
            doctorLoginWindow.Show();
            this._welcome.Close();
            RequestClose?.Invoke(this, EventArgs.Empty);


        }

      


    }
}
