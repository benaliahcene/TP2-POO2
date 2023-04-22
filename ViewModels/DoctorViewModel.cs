using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TP2_POO2.Models;
using TP2_POO2.Views;

namespace TP2_POO2.ViewModels
{
    class DoctorViewModel
    {

        public Models.Doctor Doctor { get; set; }
        public string selectDoctor { get; set; }
        public int selectIdDoctor { get; set; }

        public ObservableCollection<string> Villes { get; set; }
        public List<Models.Doctor> doctors { get; set; }
        public List<string> names { get; set; }
        public List<int> IDs { get; set; }
        private DoctorLoginWindow _doctorloginwindow;

        public ObservableCollection<string> comboboxValues { get; set; }
       
     

            public DoctorViewModel(Views.DoctorLoginWindow doctorloginwindow)
        {
            this._doctorloginwindow=doctorloginwindow;
            this.Villes = new ObservableCollection<string>()
            {
            "Rimouski",
            "Lévis",
            "Quebec",
            "Montreal"
            };
            IDs = new List<int>();
            names = new List<string>();
            TpDbContext tpDbContext = new TpDbContext();
            doctors = tpDbContext.Doctors.ToList();
             names = doctors.Select(d => d.Nom).ToList();
              IDs = doctors.Select(d => d.Id).ToList();
            comboboxValues = new ObservableCollection<string>();

            for (int i = 0; i < names.Count; i++)
            {
                string comboboxValue = $"{IDs[i]} - {names[i]}";
                comboboxValues.Add(comboboxValue);
            }


         
            DoctorCommand = new RelayCommand(
                     o=> true,
                   o => this.Welcome()
               );
            WelcomeCommand = new RelayCommand(
                o=> true,
                  o => this.Create()
              );
            QuitterCommand = new RelayCommand(
                o => true,
                o => this.Quitter());
        }

        public ICommand DoctorCommand { get; private set; }
        public ICommand WelcomeCommand { get; private set; }
        public ICommand QuitterCommand { get; private set; }

        private void Welcome()
        {
            if (!(selectDoctor==null))
            {
                int parsedId = 0;
                selectIdDoctor = 0;
                if (int.TryParse(selectDoctor.Split(' ')[0], out parsedId))
                {
                    selectIdDoctor = parsedId;
                  
                }
                else
                {
                    MessageBox.Show("erreur!", "Erreur 404", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                if (!(this.selectIdDoctor == null))
                {
                    TpDbContext tpDbContext = new TpDbContext();

                    Models.Doctor doctor = tpDbContext.Doctors.Find(selectIdDoctor);
                    // se connecter
                    GlobalWindow globalWindow = new GlobalWindow(selectIdDoctor);
                    // Fermer la fenêtre actuelle en utilisant un événement personnalisé
                    RequestClose?.Invoke(this, EventArgs.Empty);
                    // Afficher la fenêtre modale pour la création d'un nouveau profil de médecin
                    MessageBox.Show($"Bienvenu {doctor.Nom} {doctor.Prenom} !", "Sing in", MessageBoxButton.OK, MessageBoxImage.Warning);

                    globalWindow.ShowDialog();


                }

            }else
            {
                MessageBox.Show("Fait choisir le médcin!", "Sing in", MessageBoxButton.OK, MessageBoxImage.Warning);

            }




        }
        private void Create()
        {
            //  create compte
            NewDoctorWindow newDoctorWindow = new NewDoctorWindow();
            // Fermer la fenêtre actuelle en utilisant un événement personnalisé
            RequestClose?.Invoke(this, EventArgs.Empty);
            // Afficher la fenêtre modale pour la création d'un nouveau profil de médecin

            newDoctorWindow.ShowDialog();


        }
        public event EventHandler RequestClose;

        private void Quitter()
        {
            // Quitter
            Application.Current.Shutdown();

        }

    }
}
