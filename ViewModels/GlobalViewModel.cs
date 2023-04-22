using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TP2_POO2.Models;
using TP2_POO2.Views;
using KnnLibrary;
using System.IO;
using Azure.Storage.Blobs;
using System.ComponentModel;
using Microsoft.Win32;
using static Azure.Core.HttpHeader;
using System.Numerics;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;

namespace TP2_POO2.ViewModels
{
    class GlobalViewModel :INotifyPropertyChanged
    {

        private Patient _selectedPatient;
        public Patient SelectedPatient
        {
            get { return _selectedPatient; }
            set
            {
                if (_selectedPatient != value)
                {
                    _selectedPatient = value;
                    OnPropertyChanged(nameof(SelectedPatient));
                }
            }
        }

        private Models.Patient _patient;
        public List<Patient> patients { get; set; }
        public List<Historique> historiques { get; set; }

        public Models.Prediction prediction { get; set; }

         KNN_Heart _Heart { get; set; }
        public Models.Doctor doctoor { get; set; }

        public Models.Performance performance { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string _TrainFilePath;
        public string TrainFilePath
        {
            get { return _TrainFilePath; }
            set
            {
                _TrainFilePath = value;
                OnPropertyChanged(nameof(TrainFilePath));
            }
        }

        private string _TestFilePath;
        public string TestFilePath
        {
            get { return _TestFilePath; }
            set
            {
                _TestFilePath = value;
                OnPropertyChanged(nameof(TestFilePath));
            }
        }
        private Dictionary<bool, int[]> _confusionMatrix;

        public Dictionary<bool, int[]> ConfusionMatrix
        {
            get { return _confusionMatrix; }
            set
            {
                _confusionMatrix = value;
                OnPropertyChanged(nameof(ConfusionMatrix));
            }
        }

        public int idselected { get; set; }
        public Models.Patient Patient
        {
            get
            {
                if (_patient == null)
                {
                    _patient= new Patient();
                }
                return _patient;
            }
            set
            {
                _patient= value;
            }
        }
        public Models.Doctor Doctor { get; set; }
        public Models.Prediction Prediction { get; set; }
        public Models.Historique Historique { get; set; }

        public string sortie { get; set; }

        public ObservableCollection<string> Villes { get; set; }
        public List<Models.Doctor> doctors { get; set; }
        private Views.GlobalWindow _welcome;
        public List<string> names { get; set; }
        public List<int> IDs { get; set; }
        public ObservableCollection<string> comboboxValuesPatients { get; set; }
        public string selectPatient { get; set; }
        public int selectIdPatient { get; set; }

        public GlobalViewModel(int selectedId, Views.GlobalWindow globalWindow)
        {
            this.sortie = string.Empty;
            this.prediction=new Models.Prediction();
             this.performance=new Models.Performance();
            this.Historique= new Models.Historique();
            this.idselected = selectedId;
            this._welcome = globalWindow;

            this.Villes = new ObservableCollection<string>()
            {
            "Rimouski",
            "Lévis",
            "Quebec",
            "Montreal"
            };
            TpDbContext tpDbContext = new TpDbContext();
            patients = tpDbContext.Patients.Where(c => c.DoctorId == this.idselected).ToList();
            doctoor = tpDbContext.Doctors.Find(this.idselected);
            historiques= tpDbContext.Historiques.Where(c => c.DoctorId == this.idselected).ToList();


            IDs = new List<int>();
            names = new List<string>();
            names = patients.Select(d => d.Nom).ToList();
            IDs = patients.Select(d => d.Id).ToList();
            comboboxValuesPatients = new ObservableCollection<string>();

            for (int i = 0; i < names.Count; i++)
            {
                string comboboxValue = $"{IDs[i]} - {names[i]}";
                comboboxValuesPatients.Add(comboboxValue);
            }
            DeleteCommand = new RelayCommand(
                o=> true,
                o=> this.DeletePatient()

                );


            ExitCommand = new RelayCommand(
                   o => true,
                o => this.Back()
             );
            TrainFileCommand = new RelayCommand(
                   o => true,
                o => this.TrainFile()
             );
            UploadKCommand = new RelayCommand(
                   o => true,
                o => this.Kvalue()
             );
            TestFileCommand = new RelayCommand(
                   o => true,
                  o => this.TestFile()
               );
            UpadteCommand = new RelayCommand(
                   o => true,
                   o => this.UpdateCompte()
                );

            NewCompteCommand = new RelayCommand(
                   o => true,
                   o => this.NewCompte()
               );
            BackCommand = new RelayCommand(
                   o => true,
                 o => this.Quitter()
             );
            DiagnosticCommand = new RelayCommand(
                o => true,
               o => this.diagnostic()
           );



        }

        public ICommand DeleteCommand { get; private set; }


        public ICommand ExitCommand { get; private set; }

        public ICommand UploadKCommand{ get; private set; }

        public ICommand TrainFileCommand { get; private set; }
        public ICommand TestFileCommand { get; private set; }
        public ICommand NewCompteCommand { get; private set; }
        public ICommand BackCommand { get; private set; }
        public ICommand UpadteCommand { get; private set; }
        public ICommand DiagnosticCommand { get; private set; }





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
        private void TrainFile()
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                TrainFilePath = openFileDialog.FileName;
                // Traiter le fichier ici
            }
        }
        private void TestFile()
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                TestFilePath = openFileDialog.FileName;
                // Traiter le fichier ici
            }
        }

        private void diagnostic()
        {
            if (!(TrainFilePath == null || performance.K == 0 ))
            {
                this._Heart = new KNN_Heart();
                this._Heart.Train(TrainFilePath, (int)(performance.K));
               
                List<Heart> heart_samples = new List<Heart> { new Heart() { CA = this.prediction.Ca, CP = this.prediction.Cp, OldPeak = this.prediction.Oldpeak, Target = this.prediction.Target, Thal = this.prediction.Thal, Thalach = this.prediction.Thalach } };

                if (!(selectPatient == null))
                {
                    int parsedId = 0;
                    selectIdPatient = 0;
                    if (int.TryParse(selectPatient.Split(' ')[0], out parsedId))
                    {
                        selectIdPatient = parsedId;

                    }
                    else
                    {
                        MessageBox.Show("erreur!", "Erreur 404", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    if (!(this.selectIdPatient == null))
                    {

                        this.prediction.PatientId = this.selectIdPatient;
                        this.prediction.Resultat= $"\nPrediction of sample is -> {_Heart.Predict(heart_samples[0])} (expert -> {heart_samples[0].Label})\n";
                        Models.Historique historique= new Models.Historique();
                        historique.Resultat = this.prediction.Resultat;
                        historique.NameOfPatient = selectPatient;
                        historique.DateOfPrediction = DateTime.Now;
                        historique.DoctorId = this.idselected;
                        historique.K = (int)(performance.K);

                        TpDbContext tpDbContext = new TpDbContext();
                        tpDbContext.Historiques.Add(historique);
                        tpDbContext.SaveChanges();


                        MessageBox.Show($"\nPrediction of sample is -> {_Heart.Predict(heart_samples[0])} (expert -> {heart_samples[0].Label})\n", "Erreur 404", MessageBoxButton.OK, MessageBoxImage.Information);

                        Views.GlobalWindow globalWindow = new Views.GlobalWindow(this.idselected);
                        globalWindow.Show();
                        _welcome.Close();



                    }

                }
                else
                {
                    MessageBox.Show("Fait choisir le patient!", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
            }
            else
            {
                MessageBox.Show("Fait importer d'abord fichier d'apprentissage", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);

            }

        }
        private void Kvalue()
        {
            if (!(TrainFilePath== null || performance.K==0 || TestFilePath==null))
            {
                this._Heart = new KNN_Heart();

                this._Heart.Train(TrainFilePath, (int)(performance.K));
                performance.Score = this._Heart.Evaluate(TestFilePath).ToString();
                ConfusionMatrix = this._Heart.confusion_matrix;
            }else
            {
                MessageBox.Show("Attention, il faut remplir tous les champs !", "Erreur 404", MessageBoxButton.OK, MessageBoxImage.Warning);

            }


        }


        private void Quitter()
        {
            
            RequestClose?.Invoke(this, EventArgs.Empty);


        }

        private void UpdateCompte()
        {
            if(this.idselected==0)
            {
                MessageBox.Show("failed!", "Update", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            TpDbContext tpDbContext = new TpDbContext();
            Models.Doctor doc = tpDbContext.Doctors.Find(this.idselected);
            doc.Prenom=this.doctoor.Prenom;
            doc.Nom = this.doctoor.Nom;
            doc.Courriel=this.doctoor.Courriel;
            doc.Ville = this.doctoor.Ville;
            doc.Prenom = this.doctoor.Prenom;
            tpDbContext.SaveChanges();

            MessageBox.Show("Vos informations ont été modifiés avec succès!", "Update", MessageBoxButton.OK, MessageBoxImage.Information);


        }
        private void NewCompte()
        {


            Views.New_UpdatePatientWindow new_UpdatePatientWindow = new New_UpdatePatientWindow(this.idselected);
            new_UpdatePatientWindow.Show();
            _welcome.Close();


        }
        private void Back()
        {
            Views.DoctorLoginWindow doctorLoginWindow = new Views.DoctorLoginWindow();
            doctorLoginWindow.Show();
            _welcome.Close();


        }

       

        private void DeletePatient()
        {
            
                TpDbContext tpDbContext = new TpDbContext();
                if (SelectedPatient== null)
                {
                    MessageBox.Show("Opération érronée", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);


                }
                else
                {
                    int IdDelete = SelectedPatient.Id;
                    Models.Patient pat = tpDbContext.Patients.Find(IdDelete);
                    tpDbContext.Patients.Remove(pat);
                    tpDbContext.SaveChanges();

                    MessageBox.Show($"Opération a été fait avec success /{pat.Nom} a été supprimé ", "Delete", MessageBoxButton.OK, MessageBoxImage.Information);

                    Views.GlobalWindow globalWindow = new Views.GlobalWindow(this.idselected);
                    globalWindow.Show();
                    _welcome.Close();
                }
  
            
        }

    }
   

}
