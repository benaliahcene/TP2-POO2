using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TP2_POO2.Models;
using TP2_POO2.Views;

namespace TP2_POO2.ViewModels
{
    class NewPatientViewModel
    {
        private Models.Patient _patient;
        private New_UpdatePatientWindow _new_UpdatePatientWindow;
        public ObservableCollection<string> Villes { get; set; }

        public int idselected { get; set; }
        public Models.Patient Patient
        {
            get
            {
                if (_patient == null)
                {
                    _patient = new Patient();
                }
                return _patient;
            }
            set
            {
                _patient = value;
            }
        }
        public NewPatientViewModel(int id ,Views.New_UpdatePatientWindow new_UpdatePatientWindow)
        {
            this.idselected = id;
            this._new_UpdatePatientWindow = new_UpdatePatientWindow;

            this.Villes = new ObservableCollection<string>()
            {
            "Rimouski",
            "Lévis",
            "Quebec",
            "Montreal"
            };





            NewCompteCommand = new RelayCommand(
                 o => this.Patient.IsValid,
                 o => this.NewCompte()
            );

        }
        public ICommand NewCompteCommand { get; private set; }
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
        public void NewCompte()
        {


            Models.Patient patient = new Models.Patient();
            patient.Nom = this.Patient.Nom;
            patient.Prenom = this.Patient.Prenom;
            patient.DateN = this.Patient.DateN;
            patient.Courriel = this.Patient.Courriel;
            patient.DoctorId = this.idselected;


            if (IsMaleSelected)
            {
                patient.Genre = "Masculin";
            }
            else
            {
                patient.Genre = "Féminin";
            }
            patient.Ville = this.Patient.Ville;

            TpDbContext tpDbContext = new TpDbContext();
            tpDbContext.Patients.Add(patient);
            tpDbContext.SaveChanges();


            MessageBox.Show("Votre patient a été ajouté avec succès!", "Add", MessageBoxButton.OK, MessageBoxImage.Information);

            GlobalWindow globalWindow = new GlobalWindow(this.idselected);
            globalWindow.Show();

            _new_UpdatePatientWindow.Close();

        }


    } 
}
