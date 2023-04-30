using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TP2_POO2.Models
{
   public  class Patient : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [Key]
        public int Id { get; set; }


        private string _nom;
        public string Nom
        {
            get { return this._nom; }
            set
            {
                if (this._nom != value)
                {
                    this._nom = value;
                    SetIsValid();
                    this.OnPropertyChanged();
                }
            }
        }
        private string _prenom;
        public string Prenom
        {
            get { return this._prenom; }
            set
            {
                if (this._prenom != value)
                {
                    this._prenom = value;
                    SetIsValid();
                    this.OnPropertyChanged();
                }
            }
        }
        private string _courriel;
        public string Courriel
        {
            get { return this._courriel; }
            set
            {
                if (this._courriel != value)
                {
                    this._courriel = value;
                    SetIsValid();
                    this.OnPropertyChanged();
                }
            }
        }
        private string _genre;
        public string Genre
        {
            get { return this._genre; }
            set
            {
                if (this._genre != value)
                {
                    this._genre = value;
                    SetIsValid();
                    this.OnPropertyChanged();
                }
            }
        }
        private string _ville;
        public string Ville
        {
            get { return this._ville; }
            set
            {
                if (this._ville != value)
                {
                    this._ville = value;
                    SetIsValid();
                    this.OnPropertyChanged();
                }
            }
        }
     

        private DateTime _dateN;
        public DateTime DateN
        {
            get { return this._dateN; }
            set
            {
                if (this._dateN != value)
                {
                    this._dateN = value;
                    OnPropertyChanged();
                }
            }
        }
        public int DoctorId { get;  set; }
        public Doctor Doctor { get; private set; }
        public ICollection<Prediction> Predictions { get; private set; }


        private bool _isValid;

        public bool IsValid
        {
            get { return this._isValid; }
        }

        private void SetIsValid()
        {
            this._isValid = !string.IsNullOrEmpty(this.Nom) && !string.IsNullOrEmpty(this.Prenom) && !string.IsNullOrEmpty(this.Courriel);
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
   
}
